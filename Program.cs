using api.Data;
using api.Models;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ConfigureServices(builder.Services);


// builder.Services.AddCors(options => options.AddPolicy("AllowEverything", builder => builder
//               .AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader()             
//             ));

builder.Services.AddControllers();
builder.Services.AddDbContext<MattContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





// services.AddScoped<IRepository, Repository<DataContext>>();
// services.AddScoped<LogUserActivity>();
// services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
// services.AddDbContext<DataContext>(options => options.UseSqlite(
//     $"Data Source={nameof(DataContext.Users)}.db"));




var app = builder.Build();

//InsertData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseCors("AllowEverything");
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );


app.UseHttpsRedirection();

app.UseRouting();

// app.UseAuthorization();

app.MapControllers();
 

app.Run();



