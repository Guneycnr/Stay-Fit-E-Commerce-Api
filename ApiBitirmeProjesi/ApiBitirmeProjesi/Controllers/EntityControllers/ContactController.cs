using ApiBitirmeProjesi.Models.Contexts;
using ApiBitirmeProjesi.Models.DTOs;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBitirmeProjesi.Controllers.EntityControllers;

[Route("api/contact")]
[ApiController]
public class ContactController : ControllerBase
{

    private readonly ETicaretDbContext _context;

    public ContactController(ETicaretDbContext context)
    {
        _context = context;
    }


    // Contact içindeki tüm veriyi dışarıya açar
    [HttpGet]
    public IEnumerable<ContactDTO> Get()
    {
        var contactDTOs = new List<ContactDTO>();

        var contacts = _context.Contacts.ToList();

        foreach (Contact item in contacts)
        {
            contactDTOs.Add(new ContactDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Email,
                Message = item.Message,
            });
        }
        return contactDTOs.ToArray();
    }


    // Kullanıcının Id ile belirttiği Contact verisini dışarıya açar 
    [HttpGet("{id}")]
    public ActionResult<ContactDTO> GetById(int id)
    {
        var contacts = _context.Contacts.Find(id);

        if (contacts is null) return NotFound();

        var contactDTO = new ContactDTO()
        {
            Id = contacts.Id,
            Name = contacts.Name,
            Email = contacts.Email,
            Message = contacts.Message,
        };

        return Ok(contactDTO);
    }


    // Contacts tablosuna contact ekler
    [HttpPost]
    public ActionResult Post(ContactCreateDTO model)
    {
        var contact = new Contact()
        {
            CreatedDate = DateTime.Now,
            Name = model.Name,
            Email = model.Email,
            Message = model.Message,
        };

        _context.Contacts.Add(contact);

        _context.SaveChanges();

        return CreatedAtAction("Get", new { id = contact.Id });
    }


    // Kullanıcının Id ile belirttiği Contact verisini günceller
    [HttpPut("{id}")]
    public ActionResult Put(int id, ContactCreateDTO model)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

        if (contact is null) return NotFound();

        contact.Name = model.Name;
        contact.Email = model.Email;
        contact.Message = model.Message;

        _context.SaveChanges();

        return NoContent();
    }


    // Kullanıcının Id ile belirttiği Contact verisini siler
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

        if (contact is null) return NotFound();

        _context.Contacts.Remove(contact);

        _context.SaveChanges();

        return NoContent();
    }
}
