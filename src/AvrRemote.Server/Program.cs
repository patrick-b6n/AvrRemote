using AvrRemote.Server.Features.Command;
using AvrRemote.Server.Features.Data;
using AvrRemote.Server.Features.Devices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ##################
//      Services
// ##################

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Commander>();
builder.Services.AddScoped<DeviceDataService>();

builder.Services.AddSingleton<DeviceLocator>();
builder.Services.AddHostedService<DeviceLocatorHostedService>();

// ##################
//  Request Pipeline
// ##################

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseBlazorFrameworkFiles();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

// ##################
//       Start
// ##################

app.Run();