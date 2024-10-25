using System.ComponentModel.DataAnnotations;
using keepr.interfaces;

namespace keepr.Models;

public class Vault : IRepoItem<int>
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    [MaxLength(1000)]
    public string Img { get; set; }
    public bool IsPrivate { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
}

public class VaultCreationDTO
{
    public string Name { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    [MaxLength(1000)]
    public string Img { get; set; }
    public bool IsPrivate { get; set; }
}