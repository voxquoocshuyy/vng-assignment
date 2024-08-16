namespace Application.Common.Interfaces;

public interface IEntityBase<T>
{
    T Id { get; set; }
}