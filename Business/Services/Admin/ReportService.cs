using eComMaster.Business.Interfaces.Admin;
using eComMaster.Data;
using eComMaster.Models.CustomerData;
using eComMaster.Models.MasterData;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace eComMaster.Business.Services.Admin
{
    public class ReportService : IReportService
    {
        // The iText7 package is used to generate reports within the system.

        private readonly ApplicationDbContext _context;
        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get the data lists needed for the report parameter select boxes
        public List<PcSeries> GetPcSeriesList() 
        {
            return _context.PcSeries
                .Where(ps => ps.PC_SERIES_STATUS != "INA" && ps.DELETED_BY == null)
                .ToList();
        }

        public List<PcModel> GetPcModelList()
        {
            return _context.PcModel
                .Where(pm => pm.PC_MODEL_STATUS != "INA" && pm.DELETED_BY == null)
                .ToList();
        }

        // The "Order History" report
        public MemoryStream GenerateOrderReport(string price) 
        {
            List<Order> orderData = GetDataForOrderReport(price);

            using var stream = new MemoryStream();
            using (var writer = new PdfWriter(stream))
            {
                using var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                var headerCellFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

                //If there is no order data, the titles and table will not be printed
                if (orderData.Count != 0)
                {
                    //Create report title and subtitles
                    document.Add(new Paragraph("Order History Report").SetFontSize(24));
                    document.Add(new Paragraph("Date: " + DateTime.Now.ToString("dd/MM/yyyy")));
                    document.Add(new Paragraph("E-Com").SetFontSize(10));

                    //Create report table
                    var table = new Table(new float[] { 2, 2, 1, 1, 1 });
                    table.AddHeaderCell(new Cell().Add(new Paragraph("PC Model").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Customer").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Amount").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Status").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Created Date").SetFont(headerCellFont).SetFontSize(14)));
                    foreach (var order in orderData)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(order.PcModel.PC_MODEL_NAME)));
                        table.AddCell(new Cell().Add(new Paragraph(order.Customer.NAME)));
                        table.AddCell(new Cell().Add(new Paragraph(order.ORDER_AMOUNT.ToString("0.##"))));
                        table.AddCell(new Cell().Add(new Paragraph(order.ORDER_STATUS)));
                        table.AddCell(new Cell().Add(new Paragraph(order.CREATED_DATE.ToString())));
                    }
                    document.Add(table);
                }
                else
                {
                    document.Add(new Paragraph("No Order data for the given parameters").SetFontSize(24));
                }

                document.Close();
            }
            return stream;
        }

        private List<Order> GetDataForOrderReport(string price) 
        {
            return _context.Order
                    .Include(o => o.PcModel)
                    .Include(o => o.Customer)
                    .Where(o => o.ORDER_AMOUNT > Decimal.Parse(price))
                    .ToList();
        }

        // The "PC Model" Report
        public MemoryStream GeneratePcModelReport(string pcSeriesId) 
        {
            List<PcModel> pcModelData = GetDataForPcModelReport(pcSeriesId);

            using var stream = new MemoryStream();
            using (var writer = new PdfWriter(stream))
            {
                using var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                var headerCellFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

                //If there is no Model data, the titles and table will not be printed
                if (pcModelData.Count != 0)
                {
                    //Create report title and subtitles
                    document.Add(new Paragraph("PC Model Report").SetFontSize(24));
                    document.Add(new Paragraph("Date: " + DateTime.Now.ToString("dd/MM/yyyy")));
                    document.Add(new Paragraph("E-Com").SetFontSize(10));

                    //Create report table
                    var table = new Table(new float[] { 2, 2, 1, 1, 1, 1, 1 });
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Series").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Name").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Description").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Model Price").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Quantity").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Created By").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Created Date").SetFont(headerCellFont).SetFontSize(14)));
                    foreach (var model in pcModelData)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(model.PC_SERIES_ID.PC_SERIES_NAME)));
                        table.AddCell(new Cell().Add(new Paragraph(model.PC_MODEL_NAME)));
                        table.AddCell(new Cell().Add(new Paragraph(GetPcModelDescription(model))));
                        table.AddCell(new Cell().Add(new Paragraph(model.MODEL_PRICE.ToString("0.##"))));
                        table.AddCell(new Cell().Add(new Paragraph(model.QUANTITY.ToString())));
                        table.AddCell(new Cell().Add(new Paragraph(model.CREATED_BY.PRIVILEGE_TYPE)));
                        table.AddCell(new Cell().Add(new Paragraph(model.CREATED_DATE.ToString())));
                    }
                    document.Add(table);
                }
                else
                {
                    document.Add(new Paragraph("No PC Model data for the given parameters").SetFontSize(24));
                }

                document.Close();
            }
            return stream;
        }

        private List<PcModel> GetDataForPcModelReport(string pcSeriesId) 
        {
            if (pcSeriesId != "all")
            {
                return _context.PcModel
                    .Include(pm => pm.CREATED_BY)
                    .Include(pm => pm.PC_SERIES_ID)
                    .Where(pm => pm.PC_SERIES_ID.PC_SERIES_ID == int.Parse(pcSeriesId) && pm.DELETED_BY == null)
                    .ToList();
            }
            else
            {
                return _context.PcModel
                    .Include(pm => pm.CREATED_BY)
                    .Include(pm => pm.PC_SERIES_ID)
                    .Where(pm => pm.DELETED_BY == null)
                    .ToList();
            }
        }

        // Handles null values for PC Description, since table cell values cannot be null.
        private static string GetPcModelDescription(PcModel pcModel) 
        {
            if (pcModel.PC_MODEL_DESCRIPTION == null)
            {
                return "";
            }
            else 
            {
                return pcModel.PC_MODEL_DESCRIPTION;
            }
        }

        // The "Payment History" report
        public MemoryStream GeneratePaymentReport(string pcModelId) 
        {
            List<Payment> paymentData = GetDataForPaymentReport(pcModelId);

            using var stream = new MemoryStream();
            using (var writer = new PdfWriter(stream))
            {
                using var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                var headerCellFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

                //If there is no Model data, the titles and table will not be printed
                if (paymentData.Count != 0)
                {
                    //Create report title and subtitles
                    document.Add(new Paragraph("Payment History Report").SetFontSize(24));
                    document.Add(new Paragraph("Date: " + DateTime.Now.ToString("dd/MM/yyyy")));
                    document.Add(new Paragraph("E-Com").SetFontSize(10));

                    //Create report table
                    var table = new Table(new float[] { 2, 2, 1, 1, 1 });
                    table.AddHeaderCell(new Cell().Add(new Paragraph("PC Model").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Code").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Amount").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Status").SetFont(headerCellFont).SetFontSize(14)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Date").SetFont(headerCellFont).SetFontSize(14)));
                    foreach (var payment in paymentData)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(payment.Order.PcModel.PC_MODEL_NAME)));
                        table.AddCell(new Cell().Add(new Paragraph(payment.PAYMENT_CODE)));
                        table.AddCell(new Cell().Add(new Paragraph(payment.AMOUNT.ToString("0.##"))));
                        table.AddCell(new Cell().Add(new Paragraph(payment.PAYMENT_STATUS)));
                        table.AddCell(new Cell().Add(new Paragraph(payment.TRANSACTION_DATE.ToString())));
                    }
                    document.Add(table);
                }
                else
                {
                    document.Add(new Paragraph("No Payment data for the given parameters").SetFontSize(24));
                }

                document.Close();
            }
            return stream;
        }

        private List<Payment> GetDataForPaymentReport(string pcModelId) 
        {
            if (pcModelId != "all")
            {
                return _context.Payment
                    .Include(p => p.Order)
                    .Include(p => p.Order.PcModel)
                    .Where(p => p.Order.PcModel.PC_MODEL_ID == int.Parse(pcModelId))
                    .ToList();
            }
            else
            {
                return _context.Payment
                    .Include(p => p.Order)
                    .Include(p => p.Order.PcModel)
                    .ToList();
            }
        }
    }
}
