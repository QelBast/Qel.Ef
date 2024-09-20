using Qel.Ef.DbClient;

namespace Qel.Experiments.Web.Rest.PassportProviderApi.Services;

public class PassportService(ILogger<PassportService> logger,
    IPersonRepository personRepo, 
    IPassportRepository passportRepo)
{
    readonly ILogger<PassportService> _logger = logger;
    readonly IPersonRepository _personRepo = personRepo;
    readonly IPassportRepository _passportRepo = passportRepo;
}
