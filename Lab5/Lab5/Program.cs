using Lab5.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRouting(options =>
    {
        options.AppendTrailingSlash = true;
        options.LowercaseUrls = true;
    
    }
);



builder.Services.AddDbContext<FaqsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FaqsContext")));



var app = builder.Build();


app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints( endPoints =>
{
    endPoints.MapControllers();

    endPoints.MapControllerRoute(
        name: "topic_category",
        pattern: "{controller=Home}/{action=Index}/topic/category/{category}"); //url mapping - top down //routing route matters

    endPoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    

});
    
app.Run();
