using ActivityTracker.Application.Mapper;
using ActivityTracker.Application.ServicesContracts;
using ActivityTracker.Infrastructure.Persistence;
using ActivityTracker.Infrastructure.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace ActivityTracker.Api.Infrastructure
{
    internal static class Extensions
    {
        internal static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Host.UseSerilog();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddTransient<ITrackerService, TrackerService>();
            builder.Services.AddDbContext<ActivityTrackerDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddMapper();

            return builder;
        }
        internal static TypeAdapterConfig GetConfigureMappingConfig()
        {
            var config = new TypeAdapterConfig();

            new ProjectMappper().Register(config);

            return config;
        }

        internal static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddSingleton(GetConfigureMappingConfig());
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }

        internal static void AddLogger()
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Information()
               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
               .WriteTo.Console(new CompactJsonFormatter())
               .CreateLogger();

            Log.Logger.Information("Logging started");
        }
    }
}
