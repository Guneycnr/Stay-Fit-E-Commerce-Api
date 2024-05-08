using ApiBitirmeProjesi.Models.Contexts;
using ApiBitirmeProjesi.Models.DTOs;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBitirmeProjesi.Controllers.EntityControllers;

[Route("api/shippers")]
[ApiController]
public class ShippersController : ControllerBase
{
    private readonly ETicaretDbContext _context;

    public ShippersController(ETicaretDbContext context)
    {
        _context = context;
    }

    // Shippers içindeki tüm veriyi dışarıya açar
    [HttpGet]
    public IEnumerable<ShipperDTO> Get()
    {
        var shipperDTOs = new List<ShipperDTO>();

        var shippers = _context.Shippers.ToList();

        foreach (Shipper item in shippers)
        {
            shipperDTOs.Add(new ShipperDTO()
            {
                Id = item.Id,
                CompanyName = item.CompanyName,
                Phone = item.Phone
            });
        }
        return shipperDTOs.ToArray();
    }


    // Kullanıcının Id ile belirttiği Shipper verisini dışarıya açar 
    [HttpGet("{id}")]
    public ActionResult<ShipperDTO> GetById(int id)
    {
        var shipper = _context.Shippers.Find(id);

        if (shipper is null) return NotFound();

        var shipperDTO = new ShipperDTO()
        {
            Id = shipper.Id,
            CompanyName = shipper.CompanyName,
            Phone = shipper.Phone
        };

        return Ok(shipperDTO);
    }


    // Shipers tablosuna Shiper ekler
    [HttpPost]
    public ActionResult Post(ShipperCreateDTO model)
    {
        var shipper = new Shipper()
        {
            CreatedDate = DateTime.Now,
            CompanyName = model.CompanyName,
            Phone = model.Phone
        };

        _context.Shippers.Add(shipper);

        _context.SaveChanges();

        return CreatedAtAction("Get", new {id = shipper.Id });
    }


    // Kullanıcının Id ile belirttiği Shipper verisini günceller
    [HttpPut("{id}")]
    public ActionResult Put(int id, ShipperCreateDTO model)
    {
        var shipper = _context.Shippers.FirstOrDefault(s => s.Id == id);

        if (shipper is null) return NotFound();

        shipper.CompanyName = model.CompanyName;
        shipper.Phone = model.Phone;

        _context.SaveChanges();

        return NoContent();
    }


    // Kullanıcının Id ile belirttiği Shipper verisini siler
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var shipper = _context.Shippers.FirstOrDefault(p => p.Id == id);

        if (shipper is null) return NotFound();

        _context.Shippers.Remove(shipper);

        _context.SaveChanges();

        return NoContent();
    }
}
