

interface IEntity
{
    Guid Id { get; }
}

record Customer(Guid Id, string Name) : IEntity;