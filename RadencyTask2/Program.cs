using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using RadencyTask2.Models;
using RadencyTask2.Models.Books.View;
using RadencyTask2.Models.Seeder;
using RadencyTask2.Models.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BooksDbContext>(opt =>
    opt.UseInMemoryDatabase("Books"));
builder.Services.AddFluentValidation(fv =>
fv.RegisterValidatorsFromAssemblyContaining<BookValidator>());
builder.Services.AddFluentValidation(fv =>
fv.RegisterValidatorsFromAssemblyContaining<RatingValidator>());
builder.Services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);

string CORSOpenPolicy = "OpenCORSPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

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

app.UseDeveloperExceptionPage();

app.UseHttpLogging();

app.UseCors(CORSOpenPolicy);

app.Run();