using Microsoft.EntityFrameworkCore;
using Reenbit.TestTask.RealTimeChat.Hubs;
using Reenbit.TestTask.RealTimeChat.Models;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddDistributedMemoryCache();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<DataRepository>();
builder.Services.AddIdentity<User, IdentityRole>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<ChatDBContext>()
.AddDefaultTokenProviders();

// ��������� �������� ApplicationContext � �������� ������� � ����������
//builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source=HOME-PC\\SQLEXPRESS;Initial Catalog=ChatDB;Integrated Security=True"));
builder.Services.AddDbContext<ChatDBContext>(options =>
                options.UseSqlServer("Server=tcp:mikidb.database.windows.net,1433;Initial Catalog=ChatDB;Persist Security Info=False;User ID=Miki;Password=Qaqa10qa;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));




builder.Services.AddSession(options =>
{

});
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.PropertyNamingPolicy = null;
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    
});
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
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");
app.MapHub<ChatHub>("/chatHub");
app.Run();
