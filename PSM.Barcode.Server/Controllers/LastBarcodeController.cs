using Microsoft.AspNetCore.Mvc;
using PSM.Barcode.Server.DB;
using PSM.Barcode.Srv.Server.Controllers;

namespace PSM.Barcode.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LastBarcodeController : ControllerBase
{
	private readonly ILogger<LastBarcodeController> _logger;
	private readonly ApplicationContext _db;

	public LastBarcodeController(ILogger<LastBarcodeController> logger, ApplicationContext db)
	{
		_logger = logger;
		_db = db;
	}

	[HttpGet(Name = "GetLastBarcode")]
	public string Get()
	{
		return _db.LastBarcodes.FirstOrDefault(lb => lb.Type == "ToMobile")?.BarCode ?? "00000000";
	}
}
