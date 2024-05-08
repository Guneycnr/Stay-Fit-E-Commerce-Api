using ApiBitirmeProjesi.Models.Contexts;
using ApiBitirmeProjesi.Models.DTOs;
using ApiBitirmeProjesi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBitirmeProjesi.Controllers.EntityControllers;

[Route("api/comments")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ETicaretDbContext _context;

    public CommentsController(ETicaretDbContext context)
    {
        _context = context;
    }


    // Comments içindeki tüm veriyi dışarıya açar
    [HttpGet]
    public IEnumerable<CommentDTO> Get()
    {
        var commentDTOs = new List<CommentDTO>();

        var comments = _context.Comments.Include(c => c.Product)
                                        .Include(c => c.AppUser)
                                        .ToList();

        foreach (Comment item in comments)
        {
            commentDTOs.Add(new CommentDTO()
            {
                Id = item.Id,
                ProductName = item.Product.ProductName,
                UserName = item.AppUser.UserName!,
                CommentLine = item.CommentLine
            });
        }
        return commentDTOs.ToArray();
    }


    // Kullanıcının Id ile belirttiği Comment verisini dışarıya açar 
    [HttpGet("{id}")]
    public ActionResult<CommentDTO> GetById(int id)
    {
        var comment = _context.Comments.Include(c => c.Product)
                                       .Include(c => c.AppUser)
                                       .Where(c => c.Id == id)
                                       .FirstOrDefault();

        if (comment is null) return NotFound();

        var commentDTO = new CommentDTO()
        {
            Id = comment.Id,
            ProductName = comment.Product.ProductName,
            UserName = comment.AppUser.UserName!,
            CommentLine = comment.CommentLine
        };
      return Ok(commentDTO);
    }


    // Comments tablosuna Comment ekler
    [HttpPost]
    public ActionResult Post(CommentCreateDTO model)
    {
        var comment = new Comment()
        {
            CreatedDate = DateTime.Now,
            ProductId = model.ProductId,
            AppUserId = model.AppUserId,
            CommentLine = model.CommentLine
        };

        _context.Comments.Add(comment);

        _context.SaveChanges();

        return CreatedAtAction("Get", new { id = comment.Id });
    }


    // Kullanıcının Id ile belirttiği Comment verisini günceller
    [HttpPut("{id}")]
    public ActionResult Put(int id, CommentCreateDTO model)
    {
        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

        if (comment is null) return NotFound();

        comment.ProductId = model.ProductId;
        comment.AppUserId = model.AppUserId;
        comment.CommentLine = model.CommentLine;

        _context.SaveChanges();

        return NoContent();
    }


    // Kullanıcının Id ile belirttiği Comment verisini siler
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var comment = _context.Comments.FirstOrDefault(c => c.Id == id);

        if (comment is null) return NotFound();

        _context.Comments.Remove(comment);

        _context.SaveChanges();

        return NoContent();
    }
}