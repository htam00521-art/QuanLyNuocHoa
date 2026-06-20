using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Collections.Generic;

namespace QuanLyNuocHoa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NuocHoaController : ControllerBase
    {
        // Chuỗi kết nối đến file database SQLite của bạn
        private string conn = "Data Source=ql_nuochoa.db";

        // Chức năng 1: Lấy danh sách toàn bộ nước hoa (GET)
        [HttpGet]
        public ActionResult Get()
        {
            using var db = new SqliteConnection(conn);
            var data = db.Query<NuocHoa>("SELECT manuoc_hoa, tennuoc_hoa, thuong_hieu, dung_tich, so_luong, gia_ban FROM nuochoa");
            return Ok(data);
        }

        // Chức năng 2: Thêm mới một sản phẩm nước hoa (POST)
        [HttpPost]
        public ActionResult Post([FromBody] NuocHoa nh)
        {
            using var db = new SqliteConnection(conn);
            // Đồng bộ chính xác tham số @so_luong viết thường theo Class Model
            string sql = "INSERT INTO nuochoa (manuoc_hoa, tennuoc_hoa, thuong_hieu, dung_tich, so_luong, gia_ban) VALUES (@manuoc_hoa, @tennuoc_hoa, @thuong_hieu, @dung_tich, @so_luong, @gia_ban)";
            db.Execute(sql, nh);
            return Ok();
        }

        // Chức năng 3: Chỉnh sửa thông tin nước hoa (PUT)
        [HttpPut]
        public ActionResult Put([FromBody] NuocHoa nh)
        {
            using var db = new SqliteConnection(conn);
            // Đồng bộ chính xác tham số so_luong=@so_luong viết thường theo Class Model
            string sql = "UPDATE nuochoa SET tennuoc_hoa=@tennuoc_hoa, thuong_hieu=@thuong_hieu, dung_tich=@dung_tich, so_luong=@so_luong, gia_ban=@gia_ban WHERE manuoc_hoa=@manuoc_hoa";
            db.Execute(sql, nh);
            return Ok();
        }

        // Chức năng 4: Xóa một sản phẩm nước hoa theo Mã (DELETE)
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            using var db = new SqliteConnection(conn);
            db.Execute("DELETE FROM nuochoa WHERE manuoc_hoa = @id", new { id = id });
            return Ok();
        }
    }

    // ĐỊNH NGHĨA LỚP ĐỐI TƯỢNG (MODEL CLASSS): Viết thường hoàn toàn để khớp 100% với JSON từ client gửi lên
    public class NuocHoa
    {
        public string manuoc_hoa { get; set; }
        public string tennuoc_hoa { get; set; }
        public string thuong_hieu { get; set; }
        public int dung_tich { get; set; }
        public int so_luong { get; set; } 
        public double gia_ban { get; set; }
    }
}