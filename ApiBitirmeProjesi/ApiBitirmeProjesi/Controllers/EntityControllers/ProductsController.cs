using ApiBitirmeProjesi.Models.Contexts;
using ApiBitirmeProjesi.Models.DTOs;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBitirmeProjesi.Controllers.EntityControllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ETicaretDbContext _context;
    public ProductsController(ETicaretDbContext context)
    {
        _context = context;
    }

    // Products içindeki tüm veriyi dışarıya açar
    [HttpGet]
    public IEnumerable<ProductDTO> Get()
    {
        var productDTOs = new List<ProductDTO>();

        var products = _context.Products.Include(p => p.Category).Include(p => p.Comments).ToList();

        foreach (Product item in products)
        {
            productDTOs.Add(new ProductDTO()
            {
                Id = item.Id,
                CategoryName = item.Category.CategoryName,
                ProductName = item.ProductName,
                Description = item.Description,
                UsedMaterial = item.UsedMaterial,
                CommentLine = item.Comments.FirstOrDefault()?.CommentLine,
                PhotoUrl = item.PhotoUrl,
                MidPhoto = item.MidPhoto,
                LastPhoto = item.LastPhoto,
                UnitPrice = item.UnitPrice,
                UnitStock = item.UnitStock
            });
        }
        return productDTOs.ToArray();
    }


    // Kullanıcının Id ile belirttiği Product verisini dışarıya açar 
    [HttpGet("{id}")]
    public ActionResult<ProductDTO> GetById(int id)
    {
        var product = _context.Products.Include(p => p.Category)
                                       .Include(p => p.Comments)
                                       .Where(p => p.Id == id)
                                       .FirstOrDefault();

        if (product == null)
        {
            return NotFound();
        }

        var productDTO = new ProductDTO()
        {
            Id = product.Id,
            CategoryName = product.Category.CategoryName,
            ProductName = product.ProductName,
            Description = product.Description,
            UsedMaterial = product.UsedMaterial,
            CommentLine = product.Comments.FirstOrDefault()?.CommentLine,
            PhotoUrl = product.PhotoUrl,
            MidPhoto = product.MidPhoto,
            LastPhoto = product.LastPhoto,
            UnitPrice = product.UnitPrice,
            UnitStock = product.UnitStock
        };
        return Ok(productDTO);
    }


    // Products tablosuna Product ekler
    [HttpPost]
    public ActionResult Post(ProductCreateDTO model)
    {
        var product = new Product()
        {
            CreatedDate = DateTime.Now,
            ProductName = model.ProductName,
            Description = model.Description,
            UsedMaterial= model.UsedMaterial,
            PhotoUrl = model.PhotoUrl,
            MidPhoto = model.MidPhoto,
            LastPhoto = model.LastPhoto,
            UnitPrice = model.UnitPrice,
            UnitStock = model.UnitStock,
            CategoryId = model.CategoryId
        };

        _context.Products.Add(product);

        _context.SaveChanges();

        return CreatedAtAction("Get", new { id = product.Id });
    }


    // Kullanıcının Id ile belirttiği Product verisini günceller
    [HttpPut("{id}")]
    public ActionResult Put(int id, ProductCreateDTO model)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        if (product is null) return NotFound();

        product.ProductName = model.ProductName;
        product.Description = model.Description;
        product.UsedMaterial = model.UsedMaterial;
        product.PhotoUrl = model.PhotoUrl;
        product.MidPhoto = model.MidPhoto;
        product.LastPhoto = model.LastPhoto;
        product.UnitPrice = model.UnitPrice;
        product.UnitStock = model.UnitStock;
        product.CategoryId = model.CategoryId;

        _context.SaveChanges();

        return NoContent();
    }


    // Kullanıcının Id ile belirttiği Product verisini siler
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        if (product is null) return NotFound();
    
        _context.Products.Remove(product);  

        _context.SaveChanges();

        return NoContent();
    }
}
