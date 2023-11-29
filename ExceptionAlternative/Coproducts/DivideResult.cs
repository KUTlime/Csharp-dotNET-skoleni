using OneOf;

namespace ExceptionAlternative.Coproducts;

[GenerateOneOf]
public partial class DivideResult : OneOfBase<int, double, DivideByZeroException>
{
}