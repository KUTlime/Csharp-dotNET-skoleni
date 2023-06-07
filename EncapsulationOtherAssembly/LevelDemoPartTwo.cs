using Encapsulation;

namespace EncapsulationOtherAssembly
{
    internal class LevelDemoPartTwo
    {
        void NonDerivedClassDifferentAssembly()
        {
            var levelDemo = new LevelDemo();
            levelDemo._publicField = 1;
        }
    }

    internal class DerivedClass : LevelDemo
    {
        void DerivedClassDifferentAssebly()
        {
            _publicField = 1;
            _protectedInternalField = 2;
            _protectedField = 3;
        }
    }
}
