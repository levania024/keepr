using System.ComponentModel.DataAnnotations;
using keepr.interfaces;

namespace keepr.Models;

// RETURN DATA 
public class Keep : IRepoItem<int>
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    [MaxLength(1000)]
    public string Img { get; set; }
    public int Views { get; set; }

    // RELATIONSHIP properties
    public string CreatorId { get; set; }
    public int Kept { get; set; }
    public Profile Creator { get; set; }
}

public class KeepCreationDTO
{
    public string Name { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    [MaxLength(1000)]
    public string Img { get; set; }
}