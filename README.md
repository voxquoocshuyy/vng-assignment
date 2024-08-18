## README.md

### Giới thiệu dự án

**Dự án này** là một ứng dụng web được xây dựng dựa trên kiến trúc Clean Architecture, áp dụng mô hình CQRS (Command Query Responsibility Segregation), REST API và Quartz.

**Các công nghệ chính:**

* **Clean Architecture:** Tách biệt các lớp nghiệp vụ, dữ liệu và giao diện người dùng, giúp code dễ bảo trì và mở rộng.
* **CQRS:** Phân tách rõ ràng giữa các lệnh (command) và truy vấn (query), cải thiện hiệu suất và bảo mật.
* **REST API:** Cung cấp giao diện lập trình ứng dụng (API) dựa trên kiến trúc RESTful, cho phép các ứng dụng khác tương tác với hệ thống.
* **Quartz:** Lịch trình và thực thi các background job một cách linh hoạt.

### Hướng dẫn khởi động dự án

**Yêu cầu:**

* **Docker:** Đảm bảo đã cài đặt Docker và Docker Compose trên máy.

**Các bước:**

1. **Clone repository:**
   ```bash
   git clone https://github.com/voxquoocshuyy/vng-assignment
2. **Build and run:**
   ```bash
   cd vng-assignment
   docker-compose up --build
3. **Swagger UI:**
   ```bash
   http://localhost:8081/swagger
### Notes:
   Create list user:
   *lastUpdatePassword* Giá trị này nên cách thời điểm hiện tại ít nhất 6 tháng để hệ thống gửi email nhắc nhở đổi mật khẩu.
