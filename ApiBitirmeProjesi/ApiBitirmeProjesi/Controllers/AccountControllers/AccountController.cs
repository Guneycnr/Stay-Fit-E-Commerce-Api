using ApiBitirmeProjesi.Models.Authentication;
using ApiBitirmeProjesi.Models.Contexts;
using ApiBitirmeProjesi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBitirmeProjesi.Controllers.AccountControllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ETicaretDbContext _context;
    private readonly TokenService _tokenService;
    public AccountController(UserManager<AppUser> userManager, ETicaretDbContext context, TokenService tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }

    // Kullanıcı oluşturma işlemleri
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userManager.CreateAsync(new()
        {
            UserName = request.Username,
            Email = request.Email,
            Role = Role.User // Kaydolan kullanıcı direkt olarak user rolünü alır
        },
        request.Password
        );

        if (result.Succeeded)
        {
            request.Password = string.Empty;

            return CreatedAtAction(nameof(Register), new
            {
                email = request.Email,
                role = Role.User
            }, request);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }


    // Kullanıcının bilgilerini ve kayıtlı olup olmadığını kontrol eden bölüm
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUser = await _userManager.FindByEmailAsync(request.Email);

        if (managedUser is null)
        {
            return BadRequest("Yanlış Email ya da Şifre!"); // Hata mesajı
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
        if (!isPasswordValid)
        {
            return BadRequest("Yanlış Email ya da Şifre!"); // Hata mesajı
        }

        var userInDb = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (userInDb is null)
        {
            return Unauthorized();
        }

        // Kullanıcıya token verdiğimiz bölüm
        var accesToken = _tokenService.CreateToken(userInDb);

        await _context.SaveChangesAsync();

        return Ok(new AuthResponse()
        {
            id = userInDb.Id,
            Username = userInDb.UserName!,
            Email = userInDb.Email!,
            Role = userInDb.Role!,
            Token = accesToken
        });

    }
}
