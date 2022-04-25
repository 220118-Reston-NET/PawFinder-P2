global using Serilog;
using Azure.Storage.Blobs;
using PawFinderBL;
using PawFinderDL;
using Backend.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;


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

builder.Services.AddAuthentication(options =>{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("SecretKey"))),
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer  = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>{
    options.AddPolicy("UserOnly", 
        policy => policy.RequireClaim("User"));
});





builder.Services.AddDbContext<PawFinderDBcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Reference2DB")));
//builder.Services.AddScoped<IRepository>(repo => new SQLRepository(builder.Configuration.GetConnectionString("Reference2DB")));
builder.Services.AddScoped<IRepository, DBcontextRepository>();
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
// app.UseEndpoints(
//     endpoints => {
//         endpoints.MapControllers();
//         endpoints.MapHub<ChatHub>("/chart"); //This is the SignalR endpoint
//     }
// );
app.Run();
