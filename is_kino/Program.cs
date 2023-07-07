
using is_kino.Domain.DomainModels;
using is_kino.Domain.Identity;
using is_kino.Models;
using is_kino.Repository;
using is_kino.Repository.Implementation;
using is_kino.Repository.Interface;
using is_kino.Service;
using is_kino.Service.Implementation;
using is_kino.Service.Interface;
using MailKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));



//builder.Services.AddScoped( typeof(IEmailService), typeof(EmailService) );
//builder.Services.AddTransient<IBackgroundEmailSender, BackgroundEmailSender>();
//builder.Services.AddHostedService<ConsumeScopedHostedService>();

builder.Services.AddTransient<ITicketService,TicketService>();
builder.Services.AddTransient<IOrderService,OrderService>();
builder.Services.AddTransient<IMovieService,MovieService>();
//builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => 
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


//builder.Configuration.GetSection("EmailSettings");
//builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
