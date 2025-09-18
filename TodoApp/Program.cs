using System.ComponentModel.Design;
using TodoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddTransient<IMerchantServices, MerchantService>();
builder.Services.AddSingleton<IMerchantServices, MerchantService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();// register service when run api  it service create  openai document
var app = builder.Build();



//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();// generate JSON
    app.UseSwaggerUI();//it is a document for document ui show UI at swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
