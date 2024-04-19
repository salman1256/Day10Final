using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PassportAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

builder.Services.AddDbContext<PassportDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PassportDbContext") ?? throw new InvalidOperationException("Connection string 'PassportDbContext' not found.")));

// Add services to the container.
//builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(
                options =>
                {
                    { options.JsonSerializerOptions.PropertyNamingPolicy = null; };
                    { options.JsonSerializerOptions.DictionaryKeyPolicy = null; }
                }

                ); 
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
app.UseCors(options=>options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
