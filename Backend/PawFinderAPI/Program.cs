global using Serilog;
using Azure.Storage.Blobs;
using PawFinderBL;
using PawFinderDL;
// using AzureBlob.Api.Logics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
            .WriteTo.File("./.logs/api.txt")
            .CreateLogger();

builder.Services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository>(repo => new SQLRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IUserBL, UserBL>();

builder.Services.AddScoped(_ => {
  return new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage"));
});
// builder.Services.AddScoped<IFileManagerLogic, FileManagerLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
