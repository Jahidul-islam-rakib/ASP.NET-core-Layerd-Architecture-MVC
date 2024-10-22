using LibraryManageRepository.DbConfigure;
using LibraryManageRepository.InterfaceRepository;
using LibraryManageRepository.Repository;
using Microsoft.EntityFrameworkCore;
using LibraryManageService.InterfaceService;
using LibraryManageService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Context")));


builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

builder.Services.AddScoped<ILibraryService, LibraryService>();



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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
