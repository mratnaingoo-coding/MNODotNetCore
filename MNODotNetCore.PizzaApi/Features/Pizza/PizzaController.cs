using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNODotNetCore.PizzaApi.Databases;
using MNODotNetCore.PizzaApi.Queries;
using MNODotNetCore.shared;
using static MNODotNetCore.PizzaApi.Databases.OrderResponse;

namespace MNODotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly DapperServices _dapperServices;

        public PizzaController()
        {
            _appDbContext = new AppDbContext();
            _dapperServices = new DapperServices(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtrasAsync()
        {
            var lst = await _appDbContext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }
/*
        [HttpGet("Order/{invoiceNum}")]
        public async Task<IActionResult> GetOrderAsync(string invoiceNum)
        {
            var item = await _appDbContext.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNum == invoiceNum);
            var lst = await _appDbContext.PizzaOrderDetails.Where(x => x.PizzaOrderInvoiceNum == invoiceNum).ToListAsync();

            var detail = new
            {
                Order = item,
                OrderDetails = lst
            };
            return Ok(detail);
        }*/

        [HttpGet("Order/{invoiceNum}")]
        public IActionResult GetOrder(string invoiceNum)
        {
            var item = _dapperServices.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
                       (PizzaQuery.PizzaOrderQuery, new { PizzaOrderInvoiceNum = invoiceNum });

            var lst = _dapperServices.Query<PizzaOrderInvoiceDetailModel>
                       (PizzaQuery.PizzaOrderDetailQuery, new { PizzaOrderInvoiceNum = invoiceNum });

            var model = new PizzaOrderInvoiceResponse
            {
                Order = item,
                OrderDetail = lst
            };
            return Ok(model);
        }

        [HttpPost("Order")]
        public async Task <IActionResult> OrderAsync(OrderRequest request)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == request.PizzaId);
            var total = itemPizza.Price;

            if(request.Extras.Length > 0)
            {

                var lstExtra = await _appDbContext.PizzaExtras.Where(x => request.Extras.Contains(x.ExtraId)).ToListAsync();
                total += lstExtra.Sum(x => x.extraPrice);
            }
            var invNum = DateTime.Now.ToString("yyyyMMddHHmmss");

            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                //PizzaId = request.PizzaId,
                PizzaOrderInvoiceNum = invNum,
                TotalPrice = total
            };

            List<PizzaOrderDetailsModel> pizzaOrderDetailsModel = request.Extras.Select(extraID => new PizzaOrderDetailsModel
            {
                PizzaExtraId = extraID,
                PizzaOrderInvoiceNum = invNum,
            }).ToList();

            await _appDbContext.PizzaOrders.AddAsync(pizzaOrderModel);
            await _appDbContext.PizzaOrderDetails.AddRangeAsync(pizzaOrderDetailsModel);
            await _appDbContext.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                InvoiceNum = invNum,
                Message = "Thanks for your visit.",
                TotalPrice = total,
            };
            
            return Ok(response);
        }
    }
}
