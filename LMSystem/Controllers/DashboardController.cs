using LMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LMSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly string _connectionString;

        public DashboardController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }

        public IActionResult Index()
        {
            var model = new DashboardModel();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Count Students
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Students", connection))
                {
                    try { model.TotalStudents = (int)cmd.ExecuteScalar(); } catch { }
                }

                // Count Books
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Books13", connection))
                {
                    try { model.TotalBooks = (int)cmd.ExecuteScalar(); } catch { }
                }

                // Count Librarians
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Librarians", connection))
                {
                    try { model.TotalLibrarians = (int)cmd.ExecuteScalar(); } catch { }
                }

                // Count Borrowings
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM BorrowRecords13", connection))
                {
                    try { model.TotalBorrowings = (int)cmd.ExecuteScalar(); } catch { }
                }

                // Count Publications
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Publications", connection))
                {
                    try { model.TotalPublications = (int)cmd.ExecuteScalar(); } catch { }
                }
            }

            return View(model);
        }
    }
}
