using System.Text.Json;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenAI.Chat;
using StoreApi.Models.DTOs;
using StoreApi.Models.Entities;

namespace StoreApi.Controllers
 {
     [Route("api/[controller]")]
     [ApiController]
     public class OrderController : ControllerBase
     {
         //ReadOnly = Propiedad solo utilizada en el constructor y no se puede reasignar
         private readonly StoreDbContext _context;
         private readonly IConfiguration _config;

         public OrderController(StoreDbContext context, IConfiguration config)
         {
             _context = context;
             _config = config;
         }

         [HttpGet]
         public async Task<ActionResult<List<Order>>> GetOrders()
         {
             var orders = await _context.Order
                 .Include(o => o.SystemUser)
                 .Select(o => new
                 {
                     Id = o.Id,
                     Total = o.Total,
                     CreatedAt = o.CreatedAt,
                     User = new UserDTO
                     {
                         Id = o.SystemUser.Id,
                         Email = o.SystemUser.Email,
                         FirstName = o.SystemUser.FirstName,
                         LastName = o.SystemUser.LastName,
                     }
                 })
                 .ToListAsync();

             // _context.Order.FirstOrDefaultAsync(o=>o.Id == id);
             return Ok(orders);
         }

         //Id, Total, UserId
         [HttpPost]
         public async Task<ActionResult> CreateOrder(
             [FromBody] OrderCDTO order
         )
         {
             //Si da un error regresa todito (la base de datos)
             var transaction = await _context.Database.BeginTransactionAsync();
             try
             {
                 var newOrder = new Order()
                 {
                     SystemUserId = order.SystemUserId,
                     CreatedAt = DateTime.Now,
                     Total = order.Total
                 };
                 _context.Order.Add(newOrder);
                 await _context.SaveChangesAsync();

                 //Insertar en OrderProduct
                 //Agregare muchos productos en 1 orden
                 var orderProducts = order.Products
                     .Select(x => new OrderProduct { OrderId = newOrder.Id, ProductId = x, Amount = 3 })
                     .ToList();
                 _context.OrderProducts.AddRange(orderProducts);
                 await _context.SaveChangesAsync();

                 await transaction.CommitAsync();
                 return Ok();
             }
             catch (Exception e)
             {
                 await transaction.RollbackAsync();
                 return Problem();
             }

         }

         [HttpPost("bulk")]
         public async Task<ActionResult> BulkCreateOrders([FromBody] List<OrderCDTO> orders)
         {
             if (orders == null || orders.Count == 0)
             {
                 return BadRequest("No se recibieron ordenes");
             }

             // Si yo voy a modificar varias tablas o si muevo muchos registros.
             // DEBO hacer una transaccion en SQL 
             await using var transaction = await _context.Database.BeginTransactionAsync();
             try
             {
                 // Convierte el arreglo de Dtos en un arreglo normal
                 // Porque mi dbContext necesita la entidad de Order no de OrdeDto
                 // var newOrders = new List<Order>();
                 // foreach (var orderDto in orders)
                 // {
                 //     var newOrder = new Order();
                 //     newOrder.SystemUserId = orderDto.SystemUserId;
                 //     newOrder.Total = orderDto.Total;
                 //     newOrder.CreatedAt = DateTime.Now;
                 //     newOrders.Add(newOrder);
                 // }

                 //USANDO LINQ
                 var newOrders = orders
                     .Select(o => new Order()
                         {
                             SystemUserId = o.SystemUserId,
                             CreatedAt = DateTime.Now,
                             Total = o.Total,
                             OrderProducts = o.Products
                                 .Select(op => new OrderProduct() { Amount = 1, ProductId = op })
                                 .ToList()
                         }
                     )
                     .ToList();
                 _context.Order.AddRange(newOrders);
                 await _context.SaveChangesAsync();
                 await transaction.CommitAsync();
                 return Ok("Ordenes agregada");
             }
             catch (Exception ex)
             {
                 await transaction.RollbackAsync();
                 return Problem(ex.Message);
             }
         }

         [HttpGet("ai-analyze")]
         public async Task<ActionResult> AnalyzeOrder()
         {
             // OpenAIKey -> sale de settings
             var openAIKey = _config["OpenAIKey"];
             var client = new ChatClient(
                    model:"gpt-5-mini",
                    apiKey:openAIKey
                 );
             
             // PRIMERO SE OBTIENEN LOS DATOS 
             var orders = await _context.Order
                 .Include(o => o.OrderProducts)
                 .ThenInclude(o => o.Product)
                 .ThenInclude(p=>p.Store)
                 .ToListAsync();

             var summary = orders.Select(o => new
             {
                 o.Id,
                 o.Total,
                 o.CreatedAt,
                 Product = o.OrderProducts.Select(op=> new
                 {
                     op.Product.Name,
                     op.Product.Price,
                     op.Product.Store.Description
                 })
             });
             
             // Importar el Text.Json
             var jsonData= JsonSerializer.Serialize(summary);
             // SE HACE EL PROMPT
             // Todas las ordenes, con sis productos, con sus tiendas
             var prompt = Prompts.GenerateOrdersPrompt(jsonData);
             var result = await client.CompleteChatAsync([
                 new UserChatMessage(prompt)
             ]);
             
             // LA IA ANALIZA LOS DATOS Y ME REPONDE
             
             // SE DA UNA RESPUESTA CON LOS DATOS DE LA IA
             var response = result.Value.Content[0].Text;
             return Ok(response);
         }
    }
}
