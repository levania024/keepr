namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]


[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private Auth0Provider _auth0Provider;

    public ProfilesController(Auth0Provider auth0Provider)
    {
        _auth0Provider = auth0Provider;
    }
}
