using System;

namespace Operator_2.Programs
{
    internal enum Operation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Conversion
    }

    internal enum Conversion
    {
        InchesToFeet,
        FeetToYards,
        YardsToMiles
        // You can add more conversion operations here
    }

    internal abstract class Calculator
    {
        protected double[] Numbers;
        protected Operation Op;
        protected Conversion? Conv;

        protected Calculator(double[] numbers, Operation op, Conversion? conv = null)
        {
            Numbers = numbers;
            Op = op;
            Conv = conv;
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
            double result = Numbers[0];
            for (int i = 1; i < Numbers.Length; i++)
            {
                switch (Op)
                {
                    case Operation.Addition:
                        result += Numbers[i];
                        break;
                    case Operation.Subtraction:
                        result -= Numbers[i];
                        break;
                    case Operation.Multiplication:
                        result *= Numbers[i];
                        break;
                    case Operation.Division:
                        if (Numbers[i] != 0)
                            result /= Numbers[i];
                        else
                            throw new DivideByZeroException("Cannot divide by zero");
                        break;
                }
            }
        }
    }

    internal class CCalculator : Calculator
    {
        public CCalculator(double[] numbers, Operation op, Conversion conv) : base(numbers, op, conv)
        {
        }

        public override void Calculate()
        {
            if (Op == Operation.Conversion && Conv.HasValue)
            {
                double result = Numbers[0]; // Assuming you're converting a single number

                switch (Conv.Value)
                {
                    case Conversion.InchesToFeet:
                        result /= 12;
                        break;
                    case Conversion.FeetToYards:
                        result /= 3;
                        break;
                    case Conversion.YardsToMiles:
                        result /= 1760;
                        break;
                }

                Console.WriteLine("CCalculator Conversion Result: " + result);
            }
            else
            {
                Console.WriteLine("Invalid operation for CCalculator");
            }
        }
    }
}
