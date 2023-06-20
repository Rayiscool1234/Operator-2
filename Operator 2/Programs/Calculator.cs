using System;

namespace Operator_2.Programs
{
    internal enum Operation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

    internal abstract class Calculator
    {
        protected double Number;
        protected Operation Op;

        protected Calculator(double number, Operation op)
        {
            Number = number;
            Op = op;
        }

        public abstract void Calculate();
    }

    internal class GCalculator : Calculator
    {
        public GCalculator(double number, Operation op) : base(number, op)
        {
            Console.WriteLine();
        }

        public override void Calculate()
        {
            
            Console.WriteLine("This is GCalculator. Performing operation: " + Op.ToString());
        }
    }

    internal class CCalculator : Calculator
    {
        public CCalculator(double number, Operation op) : base(number, op)
        {
        }

        public override void Calculate()
        {
            // Implement the calculation logic specific to CCalculator
            Console.WriteLine("This is CCalculator. Performing operation: " + Op.ToString());
        }
    }

    
}
