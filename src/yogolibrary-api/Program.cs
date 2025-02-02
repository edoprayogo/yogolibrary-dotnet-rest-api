using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using yogolibrary_api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region  DI
builder.Services.AddScoped<IServiceManager, ServiceManager>();    
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
#endregion

#region container
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
#endregion

#region database context migration
// builder.Services.AddDbContextPool<RepositoryDbContext>(builder =>
//     {
//         var connectionString = Configuration.GetConnectionString("Database");
//         builder.UseNpgsql(connectionString);
//     });
builder.Services.AddDbContext<RepositoryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region maping controller
builder.Services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyRefference).Assembly);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
#region  configure http request pipeline (with swagger)
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

#endregion

// app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
