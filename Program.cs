namespace server;

using dotenv.net;
using Microsoft.EntityFrameworkCore;
using server.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        DotEnv.Load(new DotEnvOptions(probeForEnv: true));

        var sqlString = Environment.GetEnvironmentVariable("CANCHIDB") ?? throw new Exception("Failed to connect...");

        builder.Services.AddControllers();

        builder.Services.AddDbContext<CanChiDbContext>(options => options.UseMySQL(sqlString));

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
