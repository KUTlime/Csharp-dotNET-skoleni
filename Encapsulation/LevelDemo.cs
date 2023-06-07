// https://i.stack.imgur.com/TNtq3.png
using Encapsulation;

namespace Encapsulation
{
    public class LevelDemo
    {
        public int _publicField;
        protected internal int _protectedInternalField;
        protected int _protectedField;
        internal int _internalField;
        private protected int _privateProtectedField;
        private int _privateField;

        void WithInTheClass()
        {
            _publicField = 1;
            _protectedInternalField = 2;
            _protectedField = 3;
            _internalField = 4;
            _privateProtectedField = 5;
            _privateField = 6;
        }
    }

    public class Demo
    {
        void NonDerivedClassSameAssembly()
        {
            var levelDemo = new LevelDemo();
            levelDemo._publicField = 1;
            levelDemo._protectedInternalField = 2;
            levelDemo._internalField = 3;
        }
    }

    public class DerivedDemo : LevelDemo
    {
        void DerivedClassSameAssembly()
        {
            _publicField = 1;
            _protectedField = 2;
            _privateProtectedField = 3;
            _protectedInternalField = 2;
            _internalField = 3;
        }
    }
}
