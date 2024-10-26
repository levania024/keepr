using System.ComponentModel.DataAnnotations;
using keepr.interfaces;

namespace keepr.Models;

public class VaultKeep : IRepoItem<int>
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int KeepId { get; set; }
    public int VaultId { get; set; }
    public string CreatorId { get; set; }
    public Keep Keep { get; set; }
}

public class VaultKeepCreationDTO
{
    public int KeepId { get; set; }
    public int VaultId { get; set; }
    public int VaultKeepId { get; set; }
}