using InventoryByawAstha.BLL.src.Interfaces;
using InventoryByawAstha.BLL.src.Interfaces.Repositories;
using InventoryByawAstha.BLL.src.Interfaces.Services;
using InventoryByawAstha.BLL.src.Services;
using InventoryByawAstha.DAL;
using InventoryByawAstha.DAL.Data;
using InventoryByawAstha.DAL.Repositories;
using InventoryByawAstha.DAL.Seed;
using InventoryByawAstha.Web.Acl;
using InventoryByawAstha.Web.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("Jwt");
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];
var secretKey = jwtSettings["Key"];
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console()
    .WriteTo.File("Logs/log-.txt",rollingInterval:RollingInterval.Day)
    .WriteTo.File("Logs/error-.txt",rollingInterval:RollingInterval.Day,restrictedToMinimumLevel:Serilog.Events.LogEventLevel.Error)
    .CreateLogger();
builder.Host.UseSerilog(); 
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddDbContext<InventoryByawAsthaDbContext>(options => options.
 UseMySql(builder.Configuration.GetConnectionString("constr"), 
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("constr"))
,b=>b.MigrationsAssembly("InventoryByawAstha.DAL")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IProductGroupService, ProductGroupService>();
builder.Services.AddScoped<IUnitOfMeasureRepository,UnitOfMeasureRepository>();
builder.Services.AddScoped<IUnitOfMeasureService, UnitofMeasureService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IPermissionService, PermissionService>();

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();
if (string.IsNullOrWhiteSpace(secretKey)) {
    throw new InvalidOperationException("JWT Secret Key is not Configured");
}
if (string.IsNullOrWhiteSpace(issuer))
{
    throw new InvalidOperationException("Issuer is not Configured");
}
if (string.IsNullOrWhiteSpace(audience))
{
    throw new InvalidOperationException("Audience is not Configured");
}
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = key,
        ClockSkew = TimeSpan.FromMinutes(2)
    };
    
});
var app = builder.Build();


app.UseMiddleware<GlobalExceptionMiddleware>();



using (var scope=app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<InventoryByawAsthaDbContext>();
    await DbSeeder.SeedAdmin(context);
}

if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");

        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();


app.MapStaticAssets();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();
app.Run();

