using BusinessLogic;
using Model;
using DataAccess;
using Amazon.SecretsManager;
using Amazon.Extensions.NETCore.Setup;
using Amazon;
using Amazon.Runtime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var awsOptions = new AWSOptions
{
    Profile = "mylocal",
    Region = RegionEndpoint.CACentral1
};

// Register AWS services with dependency injection
builder.Services.AddDefaultAWSOptions(awsOptions);
builder.Services.AddAWSService<IAmazonSecretsManager>();
builder.Services.AddScoped<IService<User>, UserService>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapGet("/product/{id}", (int id) =>
{
    return $"Reading prdudct  with ID: {id}";

});

app.MapPost("/product", () =>{
    return "Creating a product";
});

Console.WriteLine($"ApiKey from config: {builder.Configuration["MySettings:ApiKey"]}");

app.MapControllers(); 
app.Run();

