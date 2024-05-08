using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBitirmeProjesi.Controllers.AccountControllers;

// Swager role kontrol
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    // Üyelik istemeden herkese bir yanıt döner 
    [HttpGet]
    [Route("selam")]
    public ActionResult Selam()
    {
        return Ok("Merhaba Dünya!");
    }

    // Yanıt dönmek için üyelik ister
    [Authorize]
    [HttpGet]
    [Route("yetkilibilgi")]
    public ActionResult YetkiliBilgi()
    {
        return Ok("Merhaba Dünya!");
    }

    // Yanıt dönmek kullanıcının rolünün admin olmasını ister
    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("adminbilgi")]
    public ActionResult AdminBilgi()
    {
        return Ok("Admin Bilgi!");
    }
}
