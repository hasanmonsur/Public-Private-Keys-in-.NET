using AsymEncWebApi.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// add all dependency
builder.Services.AddSingleton<DecryptionHelper>();
builder.Services.AddSingleton<EncryptionHelper>();
builder.Services.AddSingleton<KeyGenerator>();
builder.Services.AddSingleton<SignatureHelper>();
builder.Services.AddSingleton<VerificationHelper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
