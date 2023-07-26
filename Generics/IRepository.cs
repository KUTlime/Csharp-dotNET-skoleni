namespace Generics;

interface IEntityId<TId>
{
    TId Id { get; }
}

internal interface IRepository<TId, TOut, TCreateIn, TCreate>
    where TId : IEntityId
{
    public TOut GetById(TId id);

    public TCreate Create(TCreateIn createObject);
}

record Customer();
record CreateCustomerData();
record IntId() : IEntityId;

class CustomerRepository : IRepository<IntId, Customer, CreateCustomerData, Customer>
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
record GuidId() : IEntityId;

class OrderRepository : 
    IRepository<GuidId, Order, CreateOrderData, CreatedOrder>,
    IRepository<IntId, Order, CreateOrderData, CreatedOrder>
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
