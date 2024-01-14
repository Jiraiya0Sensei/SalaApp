using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalaApp.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Programari");
    options.Conventions.AllowAnonymousToPage("/Programari/Index");
    options.Conventions.AllowAnonymousToPage("/Programari/Details");

});
builder.Services.AddDbContext<SalaAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalaAppContext") ?? throw new InvalidOperationException("Connection string 'SalaAppContext' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("SalaAppContext") ?? throw new InvalidOperationException("Connection string 'SalaAppContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
.AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
