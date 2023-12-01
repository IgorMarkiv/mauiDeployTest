

using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".msix"] = "application/msix";
provider.Mappings[".appxbundle"] = "application/appxbundle";
//provider.Mappings["msix"] = "application/msix";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});


var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = fileProvider,
    RequestPath = "/home"
});

app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
