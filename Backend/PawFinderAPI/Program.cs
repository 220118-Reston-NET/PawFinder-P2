global using Serilog;
using Azure.Storage.Blobs;
using PawFinderBL;
using PawFinderDL;
using Backend.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
            .WriteTo.File("./.logs/api.txt")
            .CreateLogger();


builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


builder.Services.AddScoped<IRepository>(repo => new SQLRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IUserBL, UserBL>();

builder.Services.AddScoped(_ => {
  return new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(
    endpoints => {
        endpoints.MapControllers();
        endpoints.MapHub<ChatHub>("/chart"); //This is the SignalR endpoint
    }
);
app.Run();
