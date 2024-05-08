using ApiBitirmeProjesi.Models.Authentication;
using ApiBitirmeProjesi.Models.Contexts;
using ApiBitirmeProjesi.Models.DTOs;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiBitirmeProjesi.Controllers.EntityControllers;

[Route("api/appuser")]
[ApiController]
public class AppUsersController : ControllerBase
{
    private readonly ETicaretDbContext _context;

    public AppUsersController(ETicaretDbContext context)
    {
        _context = context;
    }


    // AppUsers içindeki tüm veriyi dışarıya açar
    [HttpGet]
    public IEnumerable<AppUserDTO> Get()
    {
        var appUserDTOs = new List<AppUserDTO>();

        var appUsers = _context.AppUsers.ToList();

        foreach (AppUser item in appUsers)
        {
            appUserDTOs.Add(new AppUserDTO()
            {
                Id = item.Id,
                UserName = item.UserName!,
                Email = item.Email!,
                PhoneNumber = item.PhoneNumber!,
                Role = item.Role,
                Adres = item.Adres,
                City = item.City,
                Country = item.Country,
            });
        }
        return appUserDTOs.ToArray();
    }


    // Kullanıcının Id ile belirttiği AppUser verisini dışarıya açar 
    [HttpGet("{id}")]
    public ActionResult<AppUserDTO> GetById(string id)
    {
        var appUser = _context.AppUsers.Find(id);

        if (appUser is null) return NotFound();

        var appUserDTO = new AppUserDTO()
        {
            Id = appUser.Id,
            UserName = appUser.UserName!,
            Email = appUser.Email!,
            PhoneNumber = appUser.PhoneNumber!,
            Role = appUser.Role,
            Adres = appUser.Adres,
            City = appUser.City,
            Country = appUser.Country,
        };
        return Ok(appUserDTO);
    }


    // AppUsers tablosuna AppUser ekler
    [HttpPost]
    public ActionResult Post(AppUserCreateDTO model)
    {
        var appUser = new AppUser()
        {
            UserName = model.UserName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Role = model.Role,
            Adres = model.Adres,
            City = model.City,
            Country = model.Country,
        };

        _context.AppUsers.Add(appUser);

        _context.SaveChanges();

        return CreatedAtAction("Get", new { id = appUser.Id });
    }


    // Kullanıcının Id ile belirttiği AppUser verisini günceller
    [HttpPut("{id}")]
    public ActionResult Put(string id, AppUserCreateDTO model)
    {
        var appUser = _context.AppUsers.FirstOrDefault(u => u.Id == id);

        if (appUser is null) return NotFound();

        appUser.UserName = model.UserName;
        appUser.Email = model.Email;
        appUser.PhoneNumber = model.PhoneNumber;
        appUser.Role = model.Role;
        appUser.Adres = model.Adres;
        appUser.City = model.City;
        appUser.Country = model.Country;

        _context.SaveChanges();

        return NoContent();
    }


    // Kullanıcının Id ile belirttiği AppUser verisini siler
    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        var appUser = _context.AppUsers.FirstOrDefault(u => u.Id == id);

        if (appUser is null) return NotFound();

        _context.AppUsers.Remove(appUser);

        _context.SaveChanges();

        return NoContent();
    }
}
