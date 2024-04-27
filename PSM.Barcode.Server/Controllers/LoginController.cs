using Microsoft.AspNetCore.Mvc;
using PSM.Barcode.Server.DB;
using PSM.Barcode.Server.Models;

namespace PSM.Barcode.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILogger<LoginController> _logger;
		private readonly ApplicationContext _db;

		public LoginController(ILogger<LoginController> logger, ApplicationContext db)
		{
			_logger = logger;
			_db = db;
		}

		[HttpPost(Name = "Login")]
		public int Get([FromBody] UserDto user)
		{
			var userId = _db.Users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password)?.UserId ?? 0;
			_logger.LogInformation($"logining: {user.Login}/{user.Password}");

			return userId;
		}
	}
}
