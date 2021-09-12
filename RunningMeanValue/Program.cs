using System;

namespace RunningMeanValue
{
    public class MeanValue
    {
        /* Method recalculates the mean value based on the new value passed
         * Input: amount of numbers sofar, previous mean value, new data point
         * Output: recalculated mean value
         */
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
    class MeanListElement
    {
        double listValue;
        MeanListElement nextElement;

        public void SetDaten(double listNewValue)
        {
            listValue = listNewValue;
            nextElement = null;
        }
        public MeanListElement AppendValue(double listNewValue)
        {
            nextElement = new MeanListElement();
            nextElement.SetDaten(listNewValue);
            return nextElement;
        }
        public void PrintToScreen()
        {
            Console.WriteLine($"Value:  {listValue}");
            if (nextElement != null)
                nextElement.PrintToScreen();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int oldN = 1;
            string strInput = "";
            double lastMean;
            double newValue = 0;
            double newMean;
            double firstValue = 0;
            string str;
            bool notYetGoodInput = true;

            MeanListElement listenAnfang = new MeanListElement();
            MeanListElement listEnd = listenAnfang;

            Console.Title = "Calculator of mean value";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
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
            listenAnfang.SetDaten(firstValue);

            while (strInput != "a")
            {
                MeanValue inst = new MeanValue();
                Console.WriteLine("\nGive new value ('a' for abort): ");
                notYetGoodInput = true;
                while (notYetGoodInput)
                {
                    try
                    {
                        str = Console.ReadLine();
                        if (str == "a")
                        {
                            listenAnfang.PrintToScreen();
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        newValue = Convert.ToDouble(str);
                        notYetGoodInput = false;
                    }
                    catch
                    {
                        Console.WriteLine("Not a value. Try again:");
                    }
                }
                newMean = inst.RunMean(oldN, lastMean, newValue);
                listEnd = listEnd.AppendValue(newValue);
                Console.WriteLine($"New mean value is: {newMean}, n: {oldN + 1}, added value: {newValue}");
                oldN += 1;
                lastMean = newMean;
            }
        }
    }
}
