using Services;
using PasswordController;
using Services.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandlerMiddleware();

app.UseSwagger();
app.UseSwaggerUI();

app.AddEndpoints();

app.UseHttpsRedirection();

app.Run();