namespace Classes;

internal class Demo
{
    public void Code()
    {
        var age = new Age(18);
        Console.WriteLine(age.Value);
        age.Value = 14;
        age.Value = 15;
    }
}
internal class Age(byte value)
{
    public byte Value
    {
        get; set => field = Validate(value);
    } = Validate(value);

    private static byte Validate(byte value) => value switch
    {
        _ when value < 15 => 15,
        _ when value > 75 => 75,
        _ => value,
    };
}
