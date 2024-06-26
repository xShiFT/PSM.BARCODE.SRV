﻿using Microsoft.EntityFrameworkCore;
using PSM.Barcode.Server.Models;

namespace PSM.Barcode.Server.DB;

public class ApplicationContext: DbContext
{
	public ApplicationContext(DbContextOptions<ApplicationContext> options)
		: base(options)
	{}

	public DbSet<LastBarcode> LastBarcodes { get; set; }
	public DbSet<PairCode> PairCodes { get; set; }

	public DbSet<Operation> Operations { get; set; }
	public DbSet<User> Users { get; set; }

	public DbSet<BasketItem> BasketItems { get; set; }
}
