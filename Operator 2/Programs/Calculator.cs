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
        protected double[] Numbers;
        protected Operation Op;

        protected Calculator(double[] numbers, Operation op)
        {
            Numbers = numbers;
            Op = op;
        }

        public abstract void Calculate();
    }

    internal class GCalculator : Calculator
    {
        public GCalculator(double[] numbers, Operation op) : base(numbers, op)
        {
        }

        public override void Calculate()
        {
            // Implement the calculation logic specific to GCalculator
            Console.WriteLine("This is GCalculator. Performing operation: " + Op.ToString());
        }
    }

    internal class CCalculator : Calculator
    {
        public CCalculator(double[] numbers, Operation op) : base(numbers, op)
        {
        }

        public override void Calculate()
        {
            // Implement the calculation logic specific to CCalculator
            Console.WriteLine("This is CCalculator. Performing operation: " + Op.ToString());
        }
    }
}
