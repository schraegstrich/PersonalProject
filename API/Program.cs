using System.Text;

using System.Data.SqlClient;
using Services;
using API.Services;

SqlConnectionStringBuilder connectionStringBuilder = new()
{
    DataSource = @"DESKTOP-CUM9PGM",
    InitialCatalog = "PersonalProjectDB",
    IntegratedSecurity = true,
    Pooling = false,
    Encrypt = true,
    TrustServerCertificate = true
};
Environment.SetEnvironmentVariable("DB_CONNECTION_STRING", connectionStringBuilder.ConnectionString);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<RecipeServices>();
builder.Services.AddScoped<IngredientServices>();
builder.Services.AddScoped<FoodItemServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();