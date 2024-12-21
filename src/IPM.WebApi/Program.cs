using IPM.Infrastructure;
using IPM.WebApi.ApiEndPoints;
using IPM.WebApi.ServicesRegister;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);


/* ------------------------------
 * Service register
 */
builder.Services.AddAuthService();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IPM.WebApi v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "fallbackToSpa",
    pattern: "{*url}",
    defaults: new { controller = "Home", action = "Index"}
);

app.AddEndPointsApi();

app.Run();
