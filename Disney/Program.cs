using Disney.Context;
using Disney.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x =>
{
    x.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddDbContext<DisneyDb>(optionsAction: options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(name: "DisneyConnectionString"));

});
builder.Services.AddTransient<ICharacterRepository, CharacterRepository>();
builder.Services.AddTransient<IGenderRepository, GenderRepository>();
builder.Services.AddTransient<IMovieSerieRepository, MovieSerieRepository>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
