namespace MNODotNetCore.PizzaApi.Queries;

public class PizzaQuery
{
    public static string PizzaOrderQuery { get; } = @"  SELECT po.*, p.PizzaName,p.PizzaPrice
                       FROM [MNODotNetTraining].[dbo].[tbl_pizzaOrder] po
                       inner join tbl_pizza p on p.PizzaId = po.PizzaId
                       where PizzaOrderInvoiceNum = @PizzaOrderInvoiceNum;";

    public static string PizzaOrderDetailQuery { get; } = @"SELECT pod.*, pe.PizzaExtraName, pe.PizzaExtraPrice
                      FROM [MNODotNetTraining].[dbo].[tbl_pizzaOrderDetail] pod
                      inner join tbl_pizzaExtra pe on pod.PizzaExtraId = pe.PizzaExtraId
                      where PizzaOrderInvoiceNum = @PizzaOrderInvoiceNum;";
}
