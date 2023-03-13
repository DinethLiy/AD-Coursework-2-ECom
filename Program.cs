using eComMaster.Business.Interfaces.Admin;
using eComMaster.Business.Interfaces.Auth;
using eComMaster.Business.Interfaces.SuperAdmin;
using eComMaster.Business.Services.Admin;
using eComMaster.Business.Services.Auth;
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
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IManageAdminsService, ManageAdminsService>();
builder.Services.AddScoped<IManagePcCategoriesService, ManagePcCategoriesService>();
builder.Services.AddScoped<IManagePcSeriesService, ManagePcSeriesService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
