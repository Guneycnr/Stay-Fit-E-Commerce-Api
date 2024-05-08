using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBitirmeProjesi.Controllers.AccountControllers;

// Sadece admin rolüne sahip olanların girebileceği panel

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class PanelController : ControllerBase
{
}
