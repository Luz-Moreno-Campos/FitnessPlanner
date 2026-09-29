using FitnessPlanner.API.ExceptionHandlers;
using FitnessPlanner.BLL.Services;
using FitnessPlanner.DAL.Context;
using FitnessPlanner.DAL.Repositories;
using FitnessPlanner.DAL.Seed;
using Microsoft.EntityFrameworkCore;

namespace FitnessPlanner.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<FitnessPlannerDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddDbContext<FitnessPlannerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            builder.Services.AddProblemDetails();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

          
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<ExerciseRepository>();
            builder.Services.AddScoped<WorkoutPlanRepository>();
            builder.Services.AddScoped<MuscleGroupRepository>();

     
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ExerciseService>();
            builder.Services.AddScoped<WorkoutPlanService>();
            builder.Services.AddScoped<MuscleGroupService>();

        
            builder.Services.AddOpenApi();


            var app = builder.Build();

            app.UseExceptionHandler();


            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider
                    .GetRequiredService<FitnessPlannerDbContext>();

                SeedData.InitializeAsync(context)
                    .GetAwaiter()
                    .GetResult();
            }

            // Configure HTTP request pipeline for Development environments
            if (app.Environment.IsDevelopment())
            {
                // Generates the /openapi/v1.json spec document
                app.MapOpenApi();

                // Hosts the interactive Swagger UI interface pointing to native OpenAPI spec
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "v1");
                    options.RoutePrefix = "swagger"; // Available at http://localhost:<port>/swagger
                });
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
