using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Mock;
using Repository.Interfaces;
using Service.Service;
using System.Text;
using WebApplication1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  ����� ����
builder.Services.AddDbContext<IContext, Datacontext>();
builder.Services.AddServiceExtension();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    }
    );

var configuration = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(configuration);

//����� CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// ����� �-Hangfire 
builder.Services.AddHangfire(config => config.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

var app = builder.Build();

//  **����� ��� ����� Hangfire (����� ����)**
app.UseHangfireDashboard();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//������
app.UseAuthentication();
app.UseAuthorization();

//  ����� CORS
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

//  ����� ����� ������ ������ �������
RecurringJob.AddOrUpdate<HungarianAlgorithmController>(
    "monthly-HungarianAlgorithm",
    algo => algo.Get(),
    Cron.Monthly);

RecurringJob.AddOrUpdate<SmtpEmailService>(
    "Weekly-EmailToMatchmaker",
    send => send.sendEmailToMatchmakerActiveMatch(),
    Cron.Weekly);

app.Run();
