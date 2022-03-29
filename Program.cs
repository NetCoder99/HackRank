using System;
using System.Collections.Generic;

namespace HackRank
{
    class Program
    {
        static void Main(string[] args)
        {

            CurrencyConverterRepository currencyConverterRepository = new CurrencyConverterRepository();
            CurrencyConverter currencyConverter = new CurrencyConverter(currencyConverterRepository);


            Console.WriteLine("Expected = 20.56, Actual = " + currencyConverter.GetConvertedAmount("USD", "MXN", 1));
            Console.WriteLine( "Expected = 6.36, Actual = " + currencyConverter.GetConvertedAmount("USD", "CAD", 5) );
            Console.WriteLine( "Expected = 0.62, Actual = " + currencyConverter.GetConvertedAmount("MXN", "CAD", 10) );
            Console.WriteLine( "Expected = 0.61, Actual = " + currencyConverter.GetConvertedAmount("DKK", "PLN", 1) );


        }
    }
}
