using Application.Common.Interfaces;

namespace Domain.Common;

public class EntityBase<TKey> : IEntityBase<TKey>
{
    public TKey Id { get; set; }
}