using Microsoft.EntityFrameworkCore;
using MTGArenaWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactJSDomain",
        policy => policy.WithOrigins("http://localhost:3000/")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()
        );
});

builder.Services.AddDbContext<MTGArenaCardLibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MTGArenaConnection"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("ReactJSDomain");
app.UseAuthorization();

app.MapControllers();

app.Run();
