namespace server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
            options.AddPolicy("Testing", policy =>
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            ));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger();

        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors("Testing");

        app.Run();
    }
}
