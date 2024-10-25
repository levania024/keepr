namespace keepr.Services;

public class VaultsService
{
    private readonly VaultsService _vaultsService;

    public VaultsService(VaultsService vaultsService)
    {
        _vaultsService = vaultsService;
    }
}
