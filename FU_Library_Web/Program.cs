using BusinessLayer.Service.Implement;
using BusinessLayer.Service.Interface;
using DataAccess.Repository.Implement;
using DataAccess.Repository.Interface;
using FU_Library_Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// register repository
builder.Services.AddScoped<IUserRepository, UserRepository>();



// register service
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddRazorPages();

// Configure session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Add authentication and authorization policies if needed
/*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied"; 
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
    options.AddPolicy("LibrarianOrAdmin", policy => policy.RequireRole("librarian", "admin"));
    options.AddPolicy("StudentOnly", policy => policy.RequireRole("student"));
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseSession(); 

app.UseAuthorization();

app.MapRazorPages();

app.Run();
