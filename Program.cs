using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Interfaces.Admin.ConfigItems;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.Home;
using eComMaster.Business.Interfaces.SuperAdmin;
using eComMaster.Business.Services.Admin;
using eComMaster.Business.Services.Admin.ConfigItems;
using eComMaster.Business.Services.Auth;
using eComMaster.Business.Services.Home;
using eComMaster.Business.Services.SuperAdmin;
using eComMaster.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// My SQL connection
var connectionString = builder.Configuration.GetConnectionString("MainConnection");
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ASP.NET Core Authentication
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Token-based security
var key = builder.Configuration.GetSection("AppSettings:TokenKey").Value;
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
    };
});
builder.Services.AddSingleton<IJwtSecurityService>(new JwtSecurityService(key));

// Session-based storage
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();// Session-based storage
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

// Interface-Service initialization
// Auth
builder.Services.AddScoped<IAuthService, AuthService>();
// Super Admin: Manage Accounts
builder.Services.AddScoped<IManageAdminsService, ManageAdminsService>();
// Admin: Home
builder.Services.AddScoped<IAdminHomeService, AdminHomeService>();
// Admin: Manage Master Data
builder.Services.AddScoped<IManagePcCategoriesService, ManagePcCategoriesService>();
builder.Services.AddScoped<IManagePcSeriesService, ManagePcSeriesService>();
builder.Services.AddScoped<IManagePcModelService, ManagePcModelService>();
builder.Services.AddScoped<IManageOrderService, ManageOrderService>();
builder.Services.AddScoped<IAdminViewPaymentService, AdminViewPaymentService>();
// Admin: Reports
builder.Services.AddScoped<IReportService, ReportService>();
// Admin: Config Item Management
builder.Services.AddScoped<IManageConfigCasingService, ManageConfigCasingService>();
builder.Services.AddScoped<IManageConfigDisplayService, ManageConfigDisplayService>();
builder.Services.AddScoped<IManageConfigGraphicsService, ManageConfigGraphicsService>();
builder.Services.AddScoped<IManageConfigMemoryService, ManageConfigMemoryService>();
builder.Services.AddScoped<IManageConfigMiscService, ManageConfigMiscService>();
builder.Services.AddScoped<IManageConfigPortsService, ManageConfigPortsService>();
builder.Services.AddScoped<IManageConfigPowerService, ManageConfigPowerService>();
builder.Services.AddScoped<IManageConfigProcessorService, ManageConfigProcessorService>();
builder.Services.AddScoped<IManageConfigStorageService, ManageConfigStorageService>();
// Customer
builder.Services.AddScoped<IManageHomeService, ManageHomeService>();
builder.Services.AddScoped<IManageSeriesService, ManageSeriesService>();
builder.Services.AddScoped<IManageModelService, ManageModelService>();
builder.Services.AddScoped<iManageCheckoutService, ManageCheckoutService>();

// Build App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
