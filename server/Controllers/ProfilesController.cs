using Microsoft.AspNetCore.Http.HttpResults;

namespace keepr.Controllers;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private Auth0Provider _auth0Provider;
    private ProfilesService _profilesService;

    public ProfilesController(Auth0Provider auth0Provider, ProfilesService profilesService)
    {
        _auth0Provider = auth0Provider;
        _profilesService = profilesService;
    }

    [HttpGet("{profileId}")]

    public async Task<ActionResult<Profile>> GetUserProfile(int profileId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Profile profile = _profilesService.GetUserProfile(profileId, userInfo?.Id);
            return Ok(profile);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
