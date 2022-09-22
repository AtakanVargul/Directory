namespace Directory.Identity.Application.Commons.Models.Persistence;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}