using Microsoft.EntityFrameworkCore;
using SEMBS.SEMBS.Data;
using SEMBS.SEMBS.Engines.Contracts;
using SEMBS.SEMBS.Engines.Implementations;
using SEMBS.SEMBS.Service.Contracts;
using SEMBS.SEMBS.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEventEngine, EventEngine>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUserEngine, UserEngine>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
