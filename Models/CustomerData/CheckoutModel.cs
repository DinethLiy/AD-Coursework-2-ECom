using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eComMaster.Models.CustomerData
{
	public class CheckoutModel
	{
        [Key]
        public string CHECKOUT_ID { get; set; }
        public string? NameBilling { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingZip { get; set; }

        public string? NameShipping { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingState { get; set; }
        public string? ShippingZip { get; set; }

        [ForeignKey("Order")]
        public int orderId { get; set; }

        public bool SameAddress { get; set; }

        public string PaymentMethod { get; set; }
    }
}

