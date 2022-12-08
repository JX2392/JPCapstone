using StudentManager.Repository.IRepository;
using StudentManager.Repository;
using Microsoft.EntityFrameworkCore;
using StudentManager.Data;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add ToastNotification
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});

// Add services to the container.
builder.Services.AddControllersWithViews();


//db context
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ;
var connectionSrting = "Server=tcp:jx2392-jump.database.windows.net,1433;Initial Catalog=StudentManager;Persist Security Info=False;User ID=JUMPPro;Password=!qazse4rfv;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionSrting));
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'StudentContext' not found.")));


Console.WriteLine(connectionSrting+"connection string");

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Teacher",
        areaName: "Teacher",
        pattern: "Teacher/{controller=TeacherHome}/{action=Index}"
    );
    endpoints.MapAreaControllerRoute(
        name: "Student",
        areaName: "Student",
        pattern: "Student/{controller=StudentHome}/{action=Index}"
    );
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseNotyf();

app.Run();
