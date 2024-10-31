namespace keepr.Services;

public class VaultKeepsService
{
    private readonly VaultKeepsRepository _vaultKeepsRepository;
    private readonly VaultsRepository _vaultsRepository;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsRepository vaultsRepository)
    {
        _vaultKeepsRepository = vaultKeepsRepository;
        _vaultsRepository = vaultsRepository;
    }

    internal VaultKeep CreateVaultKeep(VaultKeepCreationDTO creationData, string userId)
    {
        Vault vault = _vaultsRepository.GetVaultById(creationData.VaultId);

        if (vault.CreatorId != userId) throw new Exception("vault is private");

        return _vaultKeepsRepository.CreateVaultKeep(creationData, userId);
    }

    private VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        VaultKeep vaultKeep = _vaultKeepsRepository.GetVaultKeepById(vaultKeepId);
        if (vaultKeep == null) throw new Exception($"invalid vault keep id:{vaultKeepId}");
        return vaultKeep;
    }

    internal void DeleteVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);

        if (vaultKeep.CreatorId != userId) throw new Exception($"invalid id: {vaultKeepId}");

        _vaultKeepsRepository.DeleteKeep(vaultKeepId);
    }
}
