
namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {  
            var builder = WebApplication.CreateBuilder(args);

            // 1. Add CORS services to allow connections from Angular on port 4200
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // 2. Enable the CORS policy
            app.UseCors("AllowAngular");

            // 3. Define the Hello World endpoint
            app.MapGet("/api/hello", () => new { message = "Hello World from .NET Backend!" });

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
