using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechsysLog.Api.Hub;
using TechsysLog.App.IServices;
using TechsysLog.App.Services;
using TechsysLog.DI;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:4201") // Substitua pelo URL do seu cliente Angular
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials(); // Permite credenciai
        });
});
builder.Services.AddControllers();

builder.Services.AddHttpClient(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

// Configurações do JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

var secretKeyJson = jwtSettings["Secret"];
var secretKey = Encoding.ASCII.GetBytes(secretKeyJson);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

string strConnect = "Data Source=localhost;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Teste@4321;Encrypt=True;TrustServerCertificate=True;";
ResolveInject.RegisterServices(builder.Services, strConnect);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notificationHub");
});


// Configuração de roteamento e endpoints
app.MapControllers();

app.Run();
