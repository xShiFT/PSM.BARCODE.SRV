using Microsoft.AspNetCore.Mvc;
using PSM.Barcode.Server.DB;
using PSM.Barcode.Server.Models;

namespace PSM.Barcode.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
	private readonly ILogger<BasketController> _logger;
	private readonly ApplicationContext _db;

	public BasketController(ILogger<BasketController> logger, ApplicationContext db)
	{
		_logger = logger;
		_db = db;
	}

	// GET: api/<BasketController>/{userId}
	[HttpGet("{userId}")]
	public IEnumerable<string> Get(int userId)
	{
		return _db.BasketItems.Where(b => b.IdU == userId).Select(b => b.BarCode);
	}

	// POST api/<BasketController>/{userId}/one
	[HttpPost("{userId}/one")]
	public void Post(int userId, [FromBody] string value)
	{
		_db.BasketItems.Add(new BasketItem { IdU = userId, IdO = 10, BarCode = value });
		_db.SaveChanges();
	}

	// POST api/<BasketController>/{userId}/list
	[HttpPost("{userId}/list")]
	public void Post(int userId, [FromBody] IEnumerable<string> values)
	{
		foreach (var value in values)
		{
			_db.BasketItems.Add(new BasketItem { IdU = userId, IdO = 10, BarCode = value });
			_db.SaveChanges();
		}
	}

	/*
	// PUT api/<BasketController>/5
	[HttpPut("{id}")]
	public void Put(int id, [FromBody] string value)
	{
	}

	// DELETE api/<BasketController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
	}
	//*/
}
