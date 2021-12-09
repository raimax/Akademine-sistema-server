using Microsoft.EntityFrameworkCore;
using Server;
using Server.Configurations;
using Server.Data;
using Server.IRepository;
using Server.Repository;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("sqlConnection");

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString))
            );

// Auth
builder.Services.ConfigureIdentity();
builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options
               .WithOrigins(new[] { "http://localhost:3000", "https://localhost:3000" })
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
           );

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
