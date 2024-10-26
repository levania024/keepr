namespace keepr.Controllers;
public class VaultKeepsController : ControllerBase
{
    private readonly VaultKeepsService _vaultKeepsService;
    private Auth0Provider _auth0Provider;

    public VaultKeepsController(Auth0Provider auth0Provider, VaultKeepsService vaultKeepsService)
    {
        _auth0Provider = auth0Provider;
        _vaultKeepsService = vaultKeepsService;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeepCreationDTO creationData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(creationData, userInfo.Id);
            return Ok(vaultKeep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("vaultKeepId")]
    public async Task<ActionResult<VaultKeep>> DeleteVaultKeep(int vaultKeepId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            _vaultKeepsService.DeleteVaultKeep(vaultKeepId, userInfo.Id);
            return Ok($"{vaultKeepId} is deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
