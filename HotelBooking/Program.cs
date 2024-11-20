using DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Core.Abstractions;
using Core.Services;
using DAL.Abstractions;
using DAL.Repositories;
using Models.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IDataService, DataService>();
builder.Services.AddTransient<IDataStoreService, DataStoreService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IHotelService, HotelService>();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();
builder.Services.AddTransient<IRoomsRepository, RoomsRepository>();

builder.Services.AddAutoMapper(typeof(BookingProfile));
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
    var database = scope.ServiceProvider.GetRequiredService<IDataService>();
    database.InitializeDataStore();
}