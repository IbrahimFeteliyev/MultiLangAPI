using Business.Abstarct;
using Business.Concrete;
using Core.Security.Hasing;
using Core.Security.Models;
//using Core.Security.TokenHandler;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);


//builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JWTConfig"));
//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(option =>
//{
//    var key = Encoding.ASCII.GetBytes(builder.Configuration["JWTConfig:Key"]);
//    var issuer = builder.Configuration["JWTConfig:Issuer"];
//    var audience = builder.Configuration["JWTConfig:Audience"];
//    option.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(key),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        RequireExpirationTime = true,
//        ValidIssuer = issuer,
//        ValidAudience = audience
//    };
//});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings
.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ISliderDal, SliderDal>();
builder.Services.AddScoped<ISliderManager, SliderManager>();

builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddScoped<IDoctorDal, DoctorDal>();
builder.Services.AddScoped<IDoctorManager, DoctorManager>();

builder.Services.AddScoped<IWorkScheduleDal, WorkScheduleDal>();
builder.Services.AddScoped<IWorkScheduleManager, WorkScheduleManager>();


builder.Services.AddScoped<ICategoryDAL, EFCategoryDAL>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IShortInfoDAL, EFShortInfoDAL>();
builder.Services.AddScoped<IShortInfoService, ShortInfoManager>();


builder.Services.AddScoped<IAboutDAL, EFAboutDAL>();
builder.Services.AddScoped<IAboutService, AboutManager>();


builder.Services.AddScoped<IHospitalBranchDAL, EFHospitalBranchDAL>();
builder.Services.AddScoped<IHospitalBranchService, HospitalBranchManager>();

builder.Services.AddScoped<HasingHandler>();
//builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddScoped<JWTConfig>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
