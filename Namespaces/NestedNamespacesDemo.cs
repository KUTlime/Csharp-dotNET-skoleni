namespace System
{
    class MyClass
    {
        public void Demo()
        {
            var result = Text.Json.JsonSerializer.Deserialize<object>("");
        }
    }
}

namespace System.Text
{
    class MyClass
    {
        public void Demo()
        {
            var result = Json.JsonSerializer.Deserialize<object>("");
        }
    }
}

// Ekvivalentní zápis
namespace System
{
    namespace Text
    {
        class MyClass1
        {
            public void Demo()
            {
                var result = Json.JsonSerializer.Deserialize<object>("");
            }
        }
    }
}

// Ekvivalentní zápis
namespace System
{
    using Text;

    class MyClass2
    {
        public void Demo()
        {
            var result = Text.Json.JsonSerializer.Deserialize<object>("");
        }
    }
}