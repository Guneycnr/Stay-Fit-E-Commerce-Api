using ApiBitirmeProjesi.Models.Contexts;
using ApiBitirmeProjesi.Models.DTOs;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBitirmeProjesi.Controllers.EntityControllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ETicaretDbContext _context;

    public OrdersController(ETicaretDbContext context)
    {
        _context = context;
    }


    // Orders içindeki tüm veriyi dışarıya açar
    [HttpGet]
    public IEnumerable<OrderDTO> Get()
    {
        var orderDTOs = new List<OrderDTO>();

        var orders = _context.Orders.Include(o => o.AppUser)
                                    .Include(o => o.Shipper)
                                    .ToList();

        foreach (Order item in orders)
        {
            orderDTOs.Add(new OrderDTO()
            {
                Id = item.Id,
                UserName = item.AppUser.UserName!,
                OrderDate = item.OrderDate,
                CompanyName = item.Shipper.CompanyName,
                Adres = item.AppUser.Adres,
                TotalPrice = item.TotalPrice,
            });
        }
        return orderDTOs.ToArray();
    }


    // Kullanıcının Id ile belirttiği Order verisini dışarıya açar 
    [HttpGet("{id}")]
    public ActionResult<OrderDTO> GetById(int id)
    {
        var order = _context.Orders.Include(o => o.AppUser)
                                   .Include(o => o.Shipper)
                                   .Where(o => o.Id == id)
                                   .FirstOrDefault();

        if (order is null) return NotFound();

        var orderDTO = new OrderDTO()
        {
            Id = order.Id,
            UserName = order.AppUser.UserName!,
            OrderDate = order.OrderDate,
            CompanyName = order.Shipper.CompanyName,
            Adres = order.AppUser.Adres,
            TotalPrice = order.TotalPrice,
        };
        return Ok(orderDTO);
    }


    // Orders tablosuna Order ekler
    [HttpPost]
    public ActionResult Post(OrderCreateDTO model)
    {
        var order = new Order()
        {
            CreatedDate = DateTime.Now,
            OrderDate = DateTime.Now,
            TotalPrice = model.TotalPrice,
            AppUserId = model.AppUserId,
            ShipperId = model.ShipperId,
        };

        _context.Orders.Add(order);

        _context.SaveChanges();

        return CreatedAtAction("Get", new { id = order.Id });
    }


    // Kullanıcının Id ile belirttiği Order verisini günceller
    [HttpPut("{id}")]
    public ActionResult Put(int id, OrderCreateDTO model)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);

        if (order is null) return NotFound();

        order.OrderDate = model.OrderDate;
        order.TotalPrice = model.TotalPrice;
        order.AppUserId = model.AppUserId;
        order.ShipperId = model.ShipperId;

        _context.SaveChanges();

        return NoContent();
    }


    // Kullanıcının Id ile belirttiği Order verisini siler
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);

        if (order is null) return NotFound();

        _context.Orders.Remove(order);

        _context.SaveChanges();

        return NoContent();
    }
}
