using QuizAppApi.Data;
using QuizAppApi.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;  // Thêm nếu dùng AutoMapper

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext với MySQL
builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Đăng ký AutoMapper (nếu bạn đã tạo MappingProfile)
builder.Services.AddAutoMapper(typeof(Program)); 

// Đăng ký dịch vụ và repository
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<QuizRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Thêm Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Cấu hình để tránh lỗi vòng tham chiếu JSON
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

// Middleware swagger khi ở môi trường development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
