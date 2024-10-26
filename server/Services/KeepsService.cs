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

    private List<Keep> GetAllKeeps()
    {
        List<Keep> keeps = _keepsRepository.GetAllKeeps();
        return keeps;
    }

    internal List<Keep> GetAllKeeps(string userId)
    {
        List<Keep> keeps = GetAllKeeps();
        return keeps.FindAll(keep => keep.CreatorId == userId);
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

    internal List<Keep> GetKeepsInPublicVault(int vaultId, string userId)
    {
      List<Keep> keeps = _keepsRepository.GetKeepsInPublicVault(vaultId);
      return keeps;
    }
}
