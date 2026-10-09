using pdfcomplexscriptsample.Services;

var builder = WebApplication.CreateBuilder(args);

// Register the Syncfusion PDF generation service.
builder.Services.AddSingleton<PdfGenerationService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UsePathBase("/pdf-complex-script-text-sample");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Make the language generator the landing page.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pdf}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
