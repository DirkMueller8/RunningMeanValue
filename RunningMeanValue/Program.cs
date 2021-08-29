using System;

namespace RunningMeanValue
{
    public class MeanValue
    {
        public double RunMean(int oldN, double lastMean, double newValue)
        {
            double newMean = 0;
            if (oldN == -1)
            {
                throw new Exception("Invalid n value (-1)");
            }
            else
            {
                newMean = (oldN * lastMean + newValue) / (oldN + 1);
            }
            return newMean;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int oldN = 1;
            string strInput = "";
            double lastMean;
            double newValue;
            double newMean;
            double firstValue = 0;
            string str;
            double test = 0;
            bool notYetGoodInput = true;
            Console.WriteLine("This program calculates the running mean value.");
            Console.WriteLine();
            Console.WriteLine("Give first value: ");
            while (notYetGoodInput)
            {
                try
                {
                    firstValue = Convert.ToDouble(Console.ReadLine());
                    notYetGoodInput = false;
                }
                catch
                {
                    Console.WriteLine("Not a value. Try again: ");
                }
            }
            lastMean = firstValue;
            while (strInput != "a")
            {
                MeanValue inst = new MeanValue();
                Console.WriteLine("Give new value ('a' for abort): ");
                notYetGoodInput = true;
                while (notYetGoodInput)
                {
                    try
                    {
                        str = Console.ReadLine();
                        if (str == "a")
                        {
                            Environment.Exit(0);
                        }
                        test = Convert.ToDouble(str);
                        notYetGoodInput = false;
                    }
                    catch
                    {
                        Console.WriteLine("Not a value. Try again:");
                    }
                }
                newValue = test;
                newMean = inst.RunMean(oldN, lastMean, newValue);
                Console.WriteLine($"New mean value is: {newMean}, n: {oldN + 1}, added value: {newValue}");
                oldN += 1;
                lastMean = newMean;
            }
        }
    }
}
