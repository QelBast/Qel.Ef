using Microsoft.AspNetCore.Mvc;
using Qel.Ef.DbClient;

namespace Qel.Experiments.Web.Rest.BlacklistApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlacklistController(ILogger<BlacklistController> logger,
    IPersonRepository personRepo, 
    IPassportRepository passportRepo) : ControllerBase
    {
        
    }
}