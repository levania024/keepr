namespace keepr.interfaces;

public interface IRepoItem<T>
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
