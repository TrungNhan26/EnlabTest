# EnlabTest - Quiz Application API

## Giới thiệu
API Quiz test

---

## Tính năng chính
- Lấy danh sách câu hỏi của một bài quiz
- Xác thực đáp án người dùng và trả về kết quả đúng/sai
- Tính điểm và trả về kết quả bài quiz (thời gian làm bài, số câu đúng, trạng thái đỗ/trượt)

---

## Công nghệ sử dụng
- .NET 7 (ASP.NET Core Web API)
- Entity Framework Core
- MySQL
- AutoMapper
- Swagger (OpenAPI) để test API

---

## Cài đặt và chạy ứng dụng

1. Clone repo về máy:
git clone https://github.com/TrungNhan26/EnlabTest
cd EnlabTest

2. Chạy file EnLabTest.sql để tạo table cùng với seed data

3. Cấu hình chuỗi kết nối CSDL trong appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=quizdb;user=root;password=yourpassword;"
}

4. Cài đặt các package (nếu dùng Visual Studio thì restore tự động):
dotnet restore

5. Tạo database và migrate:
dotnet ef database update

6. Chạy ứng dụng
dotnet run

7. Mở Swagger UI để test API:
Mặc định tại https://localhost:5266/swagger
