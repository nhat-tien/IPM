using IPM.Infrastructure;
using IPM.WebApi.ApiEndPoints.V1;
using IPM.WebApi;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5173", "http://localhost:5286")
                                .AllowCredentials()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();

/* -----------------------------------
 * Developer-defined Services
 *
 */
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddAuthServices(builder.Configuration);
builder.Services.AddUseCaseServices();
builder.Services.AddSwaggerGenWithAuth();
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
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IPM.WebApi v1");
    });
    app.UseCors(MyAllowSpecificOrigins);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.MapIdentityApi<User>();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "fallbackToSpa",
    pattern: "{*url}",
    defaults: new { controller = "Home", action = "Index" }
);
app.MapEndPointsApi();
app.Run();
