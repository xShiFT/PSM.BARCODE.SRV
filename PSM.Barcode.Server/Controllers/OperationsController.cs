using Microsoft.AspNetCore.Mvc;
using PSM.Barcode.Server.DB;

namespace PSM.Barcode.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OperationsController : ControllerBase
	{
		private readonly ILogger<OperationsController> _logger;
		private readonly ApplicationContext _db;

		public OperationsController(ILogger<OperationsController> logger, ApplicationContext db)
		{
			_logger = logger;
			_db = db;
		}

		[HttpGet(Name = "GetOperations")]
		public IEnumerable<Operation> Get()
		{
			var list = _db.Operations.OrderBy(pc => pc.ID).ToArray();
			_logger.Log(LogLevel.Information, $"Count: {list.Length}");
			return list;
		}
	}
}
