using LoanOrigination.CustomerDetails.Models;
using LoanOrigination.Models.Account;
using LoanOrigination.Models.CustomerSearch;
//using LoanOrigination.Models.LoanHistory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDB>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("conLab"));
});
builder.Services.AddTransient<IUsersData, UserData>();


builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("conNan"));
});
builder.Services.AddScoped<ICustomerDataAccess, CustomerDataAccess>();

builder.Services.AddDbContext<CustomerDetailsDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("conNav"));
});
//configure dependencu injection for DataAccessLayer
builder.Services.AddScoped<ICustomerDetailsDataAccess, CustomerDetailsDataAccess>();

var secretKey = builder.Configuration["jwt:secretKey"];
var byteKey = Encoding.UTF8.GetBytes(secretKey);

//builder.Services.AddDbContext<LoanHistoryDBContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("conSat"));
//});

//builder.Services.AddScoped<ILoanHistoryDAO, LoanHistoryDAO>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
    options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["jwt:issuer"],
        ValidAudience = builder.Configuration["jwt:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(byteKey),

    }
    );


builder.Services.AddAuthorization(
//    options =>
//{
//    options.AddPolicy("AdminPolicy", policy =>
//    {
//        policy.RequireRole("Admin");
//    });
//}
);

//add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("clients-allowed", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("clients-allowed");

app.MapControllers();

app.Run();
