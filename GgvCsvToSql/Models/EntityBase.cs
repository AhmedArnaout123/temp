namespace GgvCsvToSql.Models;

public abstract class EntityBase
{
    public Guid Id { get; private set; }

    public DateTime CreatedDate { get; private set; }

    protected EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.Today;
    }
}