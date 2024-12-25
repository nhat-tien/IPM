using System.Reflection;
using IPM.Infrastructure;
using IPM.WebApi.ApiEndPoints.V1;
using IPM.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

/* -----------------------------------
 * Developer-defined Services
 *
 */
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddAuthServices();
builder.Services.AddUseCaseServices();
builder.Services.AddValidatorServices();
//
// -----------------------------------

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IPM.WebApi v1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.MapIdentityApi<User>();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "fallbackToSpa",
    pattern: "{*url}",
    defaults: new { controller = "Home", action = "Index" }
);
app.MapEndPointsApi();
app.Run();
