using Microsoft.AspNetCore.Mvc;
using PSM.Barcode.Server.DB;
using PSM.Barcode.Server.Models;

namespace PSM.Barcode.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
	private readonly ILogger<UsersController> _logger;
	private readonly ApplicationContext _db;

	public UsersController(ILogger<UsersController> logger, ApplicationContext db)
	{
		_logger = logger;
		_db = db;
	}

	[HttpGet(Name = "GetUsers")]
	public IEnumerable<User> Get()
	{
		var list = _db.Users.OrderBy(pc => pc.UserId).ToArray();
		_logger.Log(LogLevel.Information, $"Count: {list.Length}");
		return list;
	}
}
