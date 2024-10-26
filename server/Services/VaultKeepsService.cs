namespace keepr.Services;


public class VaultKeepsService
{
    private VaultKeepsRepository _vaultKeepsRepository;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository)
    {
        _vaultKeepsRepository = vaultKeepsRepository;
    }

    internal VaultKeep CreateVaultKeep(VaultKeepCreationDTO creationData, string userId)
    {
        return _vaultKeepsRepository.CreateVaultKeep(creationData, userId);
    }
    private VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        VaultKeep vaultKeep = _vaultKeepsRepository.GetVaultKeepById(vaultKeepId);
        if (vaultKeep == null) throw new Exception($"invalid vaultkeep id:{vaultKeepId}");
        return vaultKeep;
    }

    internal VaultKeep DeleteVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);

        if (vaultKeep.CreatorId != userId) throw new Exception($"invalid id: {vaultKeepId}");

        _vaultKeepsRepository.DeleteKeep(vaultKeepId);

        return vaultKeep;
    }
}
