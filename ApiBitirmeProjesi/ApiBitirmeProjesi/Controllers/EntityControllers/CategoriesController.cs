using ApiBitirmeProjesi.Models.Contexts;
using ApiBitirmeProjesi.Models.DTOs;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBitirmeProjesi.Controllers.EntityControllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ETicaretDbContext _context;

    public CategoriesController(ETicaretDbContext context)
    {
        _context = context;
    }


    // Categories içindeki tüm veriyi dışarıya açar
    [HttpGet]
    public IEnumerable<CategoryDTO> Get()
    {
        var categoryDTOs = new List<CategoryDTO>();

        var categories = _context.Categories.ToList();

        foreach (Category item in categories)
        {
            categoryDTOs.Add(new CategoryDTO()
            {
               Id = item.Id,
               CategoryName = item.CategoryName               
           });
        }
        return categoryDTOs.ToArray();
    }


    // Kullanıcının Id ile belirttiği Category verisini dışarıya açar 
    [HttpGet("{id}")]
    public ActionResult<CategoryDTO> GetById(int id)
    {
        var categories = _context.Categories.Find(id);

        if (categories is null) return NotFound();

        var categoryDTO = new CategoryDTO()
        {
            Id = categories.Id,
            CategoryName = categories.CategoryName
        };

        return Ok(categoryDTO);
    }
    

    // Categories tablosuna category ekler
    [HttpPost]
    public ActionResult Post(CategoryCreateDTO model)
    {
        var category = new Category()
        {
            CreatedDate = DateTime.Now,
            CategoryName = model.CategoryName
        };

        _context.Categories.Add(category);

        _context.SaveChanges();

        return CreatedAtAction("Get", new { id = category.Id });
    }


    // Kullanıcının Id ile belirttiği Category verisini günceller
    [HttpPut("{id}")]
    public ActionResult Put(int id, CategoryCreateDTO model)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category is null) return NotFound();

        category.CategoryName = model.CategoryName;

        _context.SaveChanges();

        return NoContent();
    }


    // Kullanıcının Id ile belirttiği Category verisini siler
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);

        if (category is null) return NotFound();

        _context.Categories.Remove(category);

        _context.SaveChanges();

        return NoContent();
    }
}
