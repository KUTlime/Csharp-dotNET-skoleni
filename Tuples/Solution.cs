namespace Tuples
{
    class Solution
	{
		public static (double Average, double Variance, double Deviation) Stats(IEnumerable<double> values)
		{
            var valueList = values.ToList();
			
            double average = valueList.Average();
			
            double variance = 0;
			foreach (var number in valueList)
			{
                variance += Math.Pow(number - average, 2);
            }            
            variance /= valueList.Count;

            double deviation = Math.Sqrt(variance);

            return (average, variance, deviation);
		}

        public static (double Average, double Variance, double Deviation) Stats(params double[] values) =>
            Stats(values);
    }

	namespace SolutionThree
	{
        public class Demo
        {
            public void Test()
            {
                var me = new Male() { FirstName = "Radek", LastName = "Zahradník",};
                var (firstName, lastName, birthDate) = me;
            }
        }
        public abstract class Person
        {
            public required string FirstName { get; init; }

            public required string LastName { get; init; }

            public string? MiddleName { get; init; }

            public DateTime BirthDate { get; } = DateTime.UtcNow;

            public abstract Sex Sex { get; }

            public byte Age => (byte)((DateTime.UtcNow - BirthDate).Days / 365);

            public byte NumberOfChildren { get; set; }

            public MarigeStatus Status { get; set; }

            public string Addressing
            {
                get
                {
                    if (Sex == Sex.Male)
                    {
                        return "Mr.";
                    }
                    if (Status is MarigeStatus.Single || Status is MarigeStatus.Divorced)
                    {
                        return "Ms.";
                    }
                    return "Mrs.";
                }
            }
        }

        public class Male : Person
        {
            public override Sex Sex => Sex.Male;
        }
        public enum Sex
        {
            Male = 0,
            Female = 1,
        }

        public enum MarigeStatus
        {
            Single = 0,
            Married = 1,
            Divorced = 2,
        }

        public static class PersonExtensions
        {
            public static void Deconstruct(this Person person, out string firstName, out string lastName, out DateTime birthDay)
            {
                firstName = person.FirstName;
                lastName = person.LastName;
                birthDay = person.BirthDate;
            }
        }
    }
}