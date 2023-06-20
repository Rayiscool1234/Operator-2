using Operator_2.Programs;

namespace Program
{

    class Program
    {
        static void Main()
        {
            GCalculator gCalc = new(2.0, Operation.Addition);
            gCalc.Calculate();

            CCalculator cCalc = new(3.0, Operation.Subtraction);
            cCalc.Calculate();

            Console.ReadKey();
        }
    }



}