namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly Auth0Provider _auth0Provider;
    private readonly ProfilesService _profilesService;
    private readonly KeepsService _keepsService;
    private readonly VaultsService _vaultsService;

    public ProfilesController(Auth0Provider auth0Provider, ProfilesService profilesService, KeepsService keepsService, VaultsService vaultsService)
    {
        _auth0Provider = auth0Provider;
        _profilesService = profilesService;
        _keepsService = keepsService;
        _vaultsService = vaultsService;
    }

    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetUserProfile(string profileId)
    {
        try
        {
            Profile profile = _profilesService.GetUserProfile(profileId);
            return Ok(profile);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetUserKeep(string profileId)
    {
        try
        {
            List<Keep> keeps = _keepsService.GetUserKeep(profileId);
            return Ok(keeps);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{profileId}/vaults")]
    public ActionResult<List<Vault>> GetUserVault(string profileId)
    {
        try
        {
            List<Vault> vaults = _vaultsService.GetUserVault(profileId);
            return Ok(vaults);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
