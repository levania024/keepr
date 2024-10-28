namespace keepr.Services;

public class KeepsService
{
    private readonly KeepsRepository _keepsRepository;

    public KeepsService(KeepsRepository keepsRepository)
    {
        _keepsRepository = keepsRepository;
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


    private Keep GetKeepById(int keepId)
    {
        Keep keep = _keepsRepository.GetKeepById(keepId);
        if (keep == null) throw new Exception($"invalid {keepId}");
        return keep;
    }

    internal Keep GetKeepById(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId);

        return keep;
    }

    internal Keep UpdateKeep(Keep creationData, int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId);

        if (keep.CreatorId != userId) throw new Exception($"invalid id: {keepId}");

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

    internal List<VaultKeepKeeps> GetKeepsInPublicVault(int vaultId, string userId)
    {
      List<VaultKeepKeeps> keeps = _keepsRepository.GetKeepsInPublicVault(vaultId);
      return keeps;
    }

    internal List<Keep> GetUserKeep(string profileId)
    {
        List<Keep> keeps = _keepsRepository.GetUserKeep(profileId);
        return keeps;
    }
}
