﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSM.Barcode.Server.Models;

[Table("_LastExpotedBarcode")]
public class LastBarcode
{
    [Key]
    public required string BarCode { get; set; }
    public required string Type { get; set; }
}

[Table("BarCodeOutCodes_ToMobile")]
public class PairCode
{
    [Key, MaxLength(8)]
    public required string BarCode { get; set; }
    [MaxLength(50)]
    public required string OutCode { get; set; }
}

[Table("CodeOperation")]
public class Operation
{
    [Key, Column("IdOperation")]
    public int ID { get; set; }
    [MaxLength(20), Column("DescrOperation")]
    public required string Name { get; set; }
}

public class User
{
	[Key]
	public int UserId { get; set; }
	[MaxLength(20)]
	public required string Login { get; set; }
	[MaxLength(14)]
	public required string Password { get; set; }
	[MaxLength(15)]
	public required string FirstName { get; set; }
}
public class UserDto
{
	[MaxLength(20)]
	public required string Login { get; set; }
	[MaxLength(14)]
	public required string Password { get; set; }
}

[Table("Basket_dev")]
public class BasketItem
{
    public int IdU { get; set; }
    public int IdO { get; set; }
    [Key, MaxLength(8)]
    public required string BarCode { get; set; }
}