/*
 * Syntaxe generik (např. u interface):
 * 
 * inteface INázevRozhraní<TIndentifikátorDatovéhoTypu>
 * {
 *      // nějaká implementace, která používá TIdentifikátor jako typ
 *      // u parametru funkce, typu vlastnosti, návratové hodnoty atd.
 * }
 * 
 *  Syntaxe s podmínkou
 * 
 * inteface INázevRozhraní<T> where T: INějakéJinéRozhraní
 * {
 *      // nějaká implementace, která používá T jako typ
 *      // u parametru funkce, typu vlastnosti, návratové hodnoty atd.
 * }
 */


var source = new IEntity<Guid, string>[]
{
    new Customer(Guid.NewGuid(), "asdf"),
    new Customer(Guid.NewGuid(), "asdf"),
    new Customer(Guid.NewGuid(), "asdf"),
    new Distributor(Guid.NewGuid(), "asdf"),
    new Distributor(Guid.NewGuid(), "asdf"),
    new Distributor(Guid.NewGuid(), "asdf"),
};

_ = source.Where(c => c.Id == Guid.NewGuid());

interface IEntity<TId, TName>
{
    TId Id { get; }
    TName Name { get; }
}

record Customer(Guid Id, string Name) : IEntity<Guid, string>;
record Distributor(Guid Id, string Name) : IEntity<Guid, string>;
record Order(int Id, string Name, double Amount) : IEntity<int, string>;