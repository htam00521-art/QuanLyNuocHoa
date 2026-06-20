var builder = WebApplication.CreateBuilder(args); // Khởi tạo ứng dụng 
builder.Services.AddControllers(); // Kích hoạt bộ điều khiển API 
var app = builder.Build(); // Xây dựng ứng dụng 

app.UseDefaultFiles(); // Bật tính năng tìm kiếm file mặc định (index.html) 
app.UseStaticFiles();  // Cho phép phân phối các file tĩnh trong wwwroot 
app.MapControllers();  // Ánh xạ các luồng API từ Controller 
app.Run();             // Khởi chạy hệ thống 