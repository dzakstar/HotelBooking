using DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DAL.Abstractions;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IDatabaseService, DatabaseService>();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<HotelBookingContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    CreateDatabaseIfNotExists();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void CreateDatabaseIfNotExists()
{
    using IServiceScope scope = app.Services.CreateScope();
    var database = scope.ServiceProvider.GetRequiredService<IDatabaseService>();
    database.Initialize();
}