using InsightApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using AspNetCore.ReCaptcha;
using InsightApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReCaptcha(options =>
{
    options.SiteKey = builder.Configuration["GoogleReCAPTCHA:SiteKey"];
    options.SecretKey = builder.Configuration["GoogleReCAPTCHA:SecretKey"];
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var connStr = builder.Configuration.GetConnectionString("SVGSContext");
string appPassword = builder.Configuration["EmailServiceConfig:AppPassword"];

builder.Services.AddTransient<EmailService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddDbContext<InsightUpdateCvgs2Context>(options => options.UseSqlServer(connStr));
builder.Services.AddDefaultIdentity<Account>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    options.Lockout.MaxFailedAccessAttempts = 3;
}).AddEntityFrameworkStores<InsightUpdateCvgs2Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=FirstPage}/{id?}");
app.MapRazorPages();

app.Run();
