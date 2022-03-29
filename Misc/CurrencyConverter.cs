using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    //static void Main(string[] args)
    //{
    //    //Create tests here i.e.
    //    CurrencyConverterRepository currencyConverterRepository = new CurrencyConverterRepository();
    //    CurrencyConverter currencyConverter = new CurrencyConverter(currencyConverterRepository);



    //    Console.WriteLine( "Expected = 20.56, Actual = " + currencyConverter.GetConvertedAmount("USD", "MXN", 1) );
    //    //Console.WriteLine( "Expected = 6.36, Actual = " + currencyConverter.GetConvertedAmount("USD", "CAD", 5) );
    //    //Console.WriteLine( "Expected = 0.62, Actual = " + currencyConverter.GetConvertedAmount("MXN", "CAD", 10) );
    //    //Console.WriteLine( "Expected = 0.61, Actual = " + currencyConverter.GetConvertedAmount("DKK", "PLN", 1) );
    //}
}
public class CurrencyConverter
{
    private CurrencyConverterRepository repository;
    public CurrencyConverter(CurrencyConverterRepository repository)
    {
        this.repository = repository;
    }

    public decimal GetConvertedAmount(string fromCountryCode, string toCountryCode, decimal amount)
    {
        CurrencyConverterRepository currencyConverter = new CurrencyConverterRepository();
        var cnvrtCodes   = currencyConverter.GetConversions();

        if (fromCountryCode.Equals("USD")) {
            var cnvrtCode = currencyConverter.GetConversions().Where(w => w.CountryCode == toCountryCode).ToList();
            return amount * cnvrtCode[0].RateFromUSDToCurrency;
        }

        var cnvrtCodeUSA = currencyConverter.GetConversions().Where(w => w.CountryCode == toCountryCode).ToList();
        if (cnvrtCodeUSA == null) {
            throw new Exception("Not found");
        }            
        decimal tmpAmt = amount * cnvrtCodeUSA[0].RateFromUSDToCurrency;

        var cnvrtCodeOTH = currencyConverter.GetConversions().Where(w => w.CountryCode == fromCountryCode).ToList();
        decimal rtnAmt = tmpAmt / cnvrtCodeOTH[0].RateFromUSDToCurrency;

        return rtnAmt; 
    }
}

public class CurrencyConverterRepository
{
    public IEnumerable<CurrencyConversion> GetConversions()
    {
        //RateFromUSD may be outdated values
        return new[] {
                new CurrencyConversion() { CountryCode = "USD", CurrencyName = "United States Dollars", RateFromUSDToCurrency = 1.0M },
                new CurrencyConversion() { CountryCode = "CAD", CurrencyName = "Canada Dollars", RateFromUSDToCurrency = 1.27M },
                new CurrencyConversion() { CountryCode = "MXN", CurrencyName = "Mexico Pesos", RateFromUSDToCurrency = 20.56M },
                new CurrencyConversion() { CountryCode = "CRC", CurrencyName = "Costa Rica Colons", RateFromUSDToCurrency = 642.83M },
                new CurrencyConversion() { CountryCode = "DZD", CurrencyName = "Algeria Dinars", RateFromUSDToCurrency = 140.26M },
                new CurrencyConversion() { CountryCode = "CNY", CurrencyName = "China Renminbis", RateFromUSDToCurrency = 6.35M },
                new CurrencyConversion() { CountryCode = "DKK", CurrencyName = "Denmark Krones", RateFromUSDToCurrency = 6.52M },
                new CurrencyConversion() { CountryCode = "PLN", CurrencyName = "Poland Zlotys", RateFromUSDToCurrency = 3.95M }
            };
    }
}

public class CurrencyConversion
{
    public String CountryCode;
    public String CurrencyName;
    public Decimal RateFromUSDToCurrency;
}