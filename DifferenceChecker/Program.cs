using System;
using DifferenceChecker.Lib;
using DifferenceChecker.Lib.LetterCase;
using DifferenceChecker.Lib.StringLength;

namespace DifferenceChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Too few arguments.");
                return;
            }

            var builder = new StringDifferenceCheckBuilder();
            var msg = builder
                .AddDifferenceCheck(new StringLengthDifference())
                .AddDifferenceCheck(new LetterCaseDifference())
                .WithPrinterFactory(new ConsolePrinterFactory())
                .Check(args[0], args[1])
                .Print();

            Console.WriteLine(msg);
            Console.ReadLine();

        }
    }
}
