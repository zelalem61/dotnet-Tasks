namespace BlogApi.Domain;

public abstract class BaseDomainEntity
{
    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
}
