namespace keepr.Services;

public class KeepsService
{
    private readonly KeepsRepository _keepsRepository;
    private readonly VaultsRepository _vaultsRepository;

    public KeepsService(KeepsRepository keepsRepository, VaultsRepository vaultsRepository)
    {
        _keepsRepository = keepsRepository;
        _vaultsRepository = vaultsRepository;
    }

    internal Keep CreateKeep(KeepCreationDTO creationData, string userId)
    {
        return _keepsRepository.CreateKeep(creationData, userId);
    }

    internal List<Keep> GetAllKeeps()
    {
        List<Keep> keeps = _keepsRepository.GetAllKeeps();
        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        Keep keep = _keepsRepository.GetKeepById(keepId);
        if (keep == null) throw new Exception($"invalid {keepId}");
        return keep;
    }

    internal Keep UpdateKeep(Keep creationData, int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId);

        if (keep.CreatorId != userId) throw new Exception($"Not your Keep to update");

        keep.Name = creationData.Name ?? keep.Name;
        keep.Description = creationData.Description ?? keep.Description;

        _keepsRepository.UpdateKeep(keep);

        return keep;
    }

    internal Keep DeleteKeep(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId);

        if (keep.CreatorId != userId) throw new Exception($"invalid id: {keepId}");

        _keepsRepository.DeleteKeep(keepId);

        return keep;
    }

    private Vault GetVaultById(int vaultId)
    {
        Vault vault = _vaultsRepository.GetVaultById(vaultId);
        if (vault == null) throw new Exception($"invalid Id: {vaultId}");

        return vault;
    }
    internal List<VaultKeepKeeps> GetKeepsInVault(int vaultId, string userId)
    {
        Vault vault = GetVaultById(vaultId);
        if (vault.IsPrivate == true && vault.CreatorId != userId) throw new Exception($"This vault: {vaultId} is private");
        List<VaultKeepKeeps> keeps = _keepsRepository.GetKeepsInVault(vaultId);

        return keeps;
    }

    internal List<Keep> GetUserKeep(string profileId)
    {
        List<Keep> keeps = _keepsRepository.GetUserKeep(profileId);
        return keeps;
    }
}
