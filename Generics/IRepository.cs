namespace Generics;

interface IEntityId<TId>
{
    TId Id { get; }
}

internal interface IRepository<TIentity, TOut, TCreateIn, TCreate, TId>
    where TIentity : IEntityId<TId>
{
    public TOut GetById(TIentity id);

    public TCreate Create(TCreateIn createObject);
}

record Customer();
record CreateCustomerData();
record IntId(int Id) : IEntityId<int>;

class CustomerRepository : IRepository<IntId, Customer, CreateCustomerData, Customer, int>
{
    public Customer Create(CreateCustomerData createObject)
    {
        throw new NotImplementedException();
    }

    public Customer GetById(IntId id)
    {
        throw new NotImplementedException();
    }
}

record Order();
record CreateOrderData();
record CreatedOrder();
record GuidId(Guid Id) : IEntityId<Guid>;

class OrderRepository : 
    IRepository<GuidId, Order, CreateOrderData, CreatedOrder, Guid>,
    IRepository<IntId, Order, CreateOrderData, CreatedOrder, int>
{
    public CreatedOrder Create(CreateOrderData createObject)
    {
        throw new NotImplementedException();
    }

    public Order GetById(GuidId id)
    {
        throw new NotImplementedException();
    }

    public Order GetById(IntId id)
    {
        throw new NotImplementedException();
    }
}
