using LibraryManageRepository.DbConfigure;
using LibraryManageRepository.InterfaceRepository;
using LibraryManageRepository.Repository;
using Microsoft.EntityFrameworkCore;
using LibraryManageService.InterfaceService;
using LibraryManageService.Service;
using Microsoft.AspNetCore.Identity;
using LibraryManageModel.Entities;
using LibraryManage.Helper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Context")));

builder.Services.AddAutoMapper(typeof(MappingProfile));


//register identity with LibraryMDbContext
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<LibraryDBContext>()
				.AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;
	options.User.RequireUniqueEmail = true;

});

//Services
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();


//repositaries
builder.Services.AddScoped<ILibraryService, LibraryService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	await RoleInitializer.SeedRolesAndUsers(services);
}


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
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
