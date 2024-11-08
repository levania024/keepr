namespace keepr.Services;

public class VaultsService
{
    private readonly VaultsRepository _vaultsRepository;

    public VaultsService(VaultsRepository vaultsRepository)
    {
        _vaultsRepository = vaultsRepository;
    }

    internal Vault CreateVault(VaultCreationDTO creationData, string userId)
    {
        return _vaultsRepository.CreateVault(creationData, userId);
    }

    private Vault GetVaultById(int vaultId)
    {
        Vault vault = _vaultsRepository.GetVaultById(vaultId);
        if (vault == null) throw new Exception($"invalid Id: {vaultId}");

        return vault;
    }

    internal Vault GetVaultById(int vaultId, string userId)
    {
        Vault vault = _vaultsRepository.GetVaultById(vaultId);
        if (vault.IsPrivate == true && vault.CreatorId != userId) throw new Exception($"Invalid id, vault is private");
        return vault;
    }

    internal Vault UpdateVault(int vaultId, string userId, VaultCreationDTO creationData)
    {
        Vault vault = GetVaultById(vaultId);

        if (vault.CreatorId != userId) throw new Exception($"invalid id: {vaultId}");

        vault.Name = creationData.Name ?? vault.Name;
        vault.IsPrivate = creationData.IsPrivate ?? vault.IsPrivate;

        _vaultsRepository.UpdateVault(vault);

        return vault;
    }

    internal Vault DeleteVault(int vaultId, string userId)
    {
        Vault vault = GetVaultById(vaultId);

        if (vault.CreatorId != userId) throw new Exception();

        _vaultsRepository.DeleteVault(vaultId);

        return vault;
    }

    internal List<Vault> GetMyVault(string userId)
    {
        List<Vault> vaults = _vaultsRepository.GetMyVault(userId);
        return vaults;
    }

    internal List<Vault> GetUserVault(string profileId)
    {
        List<Vault> vaults = _vaultsRepository.GetUserVault(profileId);

        return vaults.FindAll(vault => vault.IsPrivate == false || vault.CreatorId != profileId);
    }
}