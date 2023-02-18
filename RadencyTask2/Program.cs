using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RadencyTask2.Models;
using RadencyTask2.Models.Books.View;
using RadencyTask2.Models.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BooksDbContext>(opt =>
    opt.UseInMemoryDatabase("Books"));
builder.Services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

BookSeed.AddData(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();