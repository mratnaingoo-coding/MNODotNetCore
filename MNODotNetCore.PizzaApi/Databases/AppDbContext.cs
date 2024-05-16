using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNODotNetCore.PizzaApi.Databases;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if you use MySQL or Oracle or other change name behind Use.
        optionsBuilder.UseSqlServer(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<PizzaModel> Pizzas { get; set; }
    public DbSet<PizzaExtraModel> PizzaExtras { get; set; }
    public DbSet<PizzaOrderModel> PizzaOrders { get; set; }
    public DbSet<PizzaOrderDetailsModel> PizzaOrderDetails { get; set; }

}

[Table("tbl_pizza")]
public class PizzaModel
{
    [Key]
    // Column is for sqlname match.
    [Column("PizzaId")]
    public int Id { get; set; }

    [Column("PizzaName")]
    public string Name { get; set; }

    [Column("PizzaPrice")]
    public decimal Price { get; set; }
    [NotMapped]
    public string priceStr { get { return "$ " + Price; } }
}

[Table("tbl_pizzaExtra")]
public class PizzaExtraModel
{
    [Key]
    [Column("PizzaExtraId")]
    public int ExtraId { get; set; }

    [Column("PizzaExtraName")]
    public string extraName { get; set; }

    [Column("PizzaExtraPrice")]
    public decimal extraPrice { get; set; }
    [NotMapped]
    public string priceStr { get { return "$ " + extraPrice; } }
}

public class OrderRequest
{
    public int PizzaId { get; set; }
    public int[] Extras { get; set; }
}
public class OrderResponse
{
    public string Message { get; set; }
    public string InvoiceNum { get; set; }
    public decimal TotalPrice { get; set; }
}

[Table("tbl_pizzaOrder")]

public class PizzaOrderModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PizzaOrderId { get; set; }
    public string? PizzaOrderInvoiceNum { get; set; }
    public int PizzaId { get; set; }
    public decimal TotalPrice { get; set;}

}

[Table("tbl_pizzaOrderDetail")]
public class PizzaOrderDetailsModel
{
    [Key]
    public int PizzaOrderDetailsId { get; set; }
    public string PizzaOrderInvoiceNum { get; set; }
    public int PizzaExtraId { get; set; }
}

public class PizzaOrderInvoiceHeadModel
{
    public int PizzaOrderId { get; set; }
    public string? PizzaOrderInvoiceNum { get; set; }
    public int PizzaId { get; set; }
    public decimal TotalPrice { get; set; }
    public string PizzaName { get; set; }
    public decimal PizzaPrice { get; set; }

}
public class PizzaOrderInvoiceDetailModel
{
    public int PizzaOrderDetailsId { get; set; }
    public string PizzaOrderInvoiceNum { get; set; }
    public int PizzaExtraId { get; set; }
    public string PizzaExtraName { get; set; }
    public decimal PizzaExtraPrice { get; set; }
}
public class PizzaOrderInvoiceResponse
{
    public PizzaOrderInvoiceHeadModel Order { get; set; }
    public List <PizzaOrderInvoiceDetailModel>  OrderDetail { get; set; }
}