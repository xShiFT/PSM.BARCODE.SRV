using Microsoft.AspNetCore.Mvc;
using PSM.Barcode.Server.DB;

namespace PSM.Barcode.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LastBarcodesController : ControllerBase
	{
		private readonly ILogger<LastBarcodesController> _logger;
		private readonly ApplicationContext _db;

		public LastBarcodesController(ILogger<LastBarcodesController> logger, ApplicationContext db)
		{
			_logger = logger;
			_db = db;
		}

		[HttpGet(Name = "GetLastBarcodes")]
		public IEnumerable<PairCode> Get()
		{
			var list = _db.PairCodes.OrderBy(pc => pc.BarCode).Take(100).ToArray();
			_logger.Log(LogLevel.Information, $"Count: {list.Length}");
			return list;
		}
	}
}
