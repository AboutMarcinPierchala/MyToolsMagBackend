using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyToolsMag.ApplicationServices.API.Domain;
using MyToolsMag.ApplicationServices.API.Validators;
using MyToolsMag.ApplicationServices.Mappings;
using MyToolsMag.DataAccess;
using MyToolsMag.DataAccess.CQRS;
using System.Reflection;
using NLog.Web;
using Microsoft.AspNetCore.Authentication;
using MyToolsMag.Authentication;
using Microsoft.Extensions.DependencyInjection;
using MyToolsMag.Controllers;
using Microsoft.AspNetCore.Hosting;
using MyToolsMag.ApplicationServices.Components.PasswordHasher;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
            //.WithOrigins("https://localhost:44330");
            //.SetIsOriginAllowed(origin => true); // allow any origin
                    //.AllowCredentials(); // allow credentials;
            //.WithOrigins("http://localhost/*",
            //                   "https://localhost/*");
            //.AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .SetIsOriginAllowed(origin => true) // allow any origin
            //        .AllowCredentials()); // allow credentials
});

});


builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace); //used only for try how its working - in prod version will by disabled
builder.WebHost.UseNLog();

//builder.Services.AddMvcCore()
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddPersonRequestValidator>());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AddToolCategoryRequestValidator>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddAutoMapper(typeof(ToolsProfile).Assembly);
//builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(), typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ResponseBase<>).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApiControllerBase).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(BasicAuthenticationHandler).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ControllerBase).Assembly));
//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<WarehouseStorageContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseDatabaseConnectionString"), options => options.EnableRetryOnFailure()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


var app = builder.Build();

var scope = app.Services.CreateScope();
//var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
//seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MapControllers();

app.Run();
