using Examples.Chapter3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaYumba;
using LaYumba.Functional; 

namespace Examples.Chapter05
{
    public class Class
    {
    }

    [TestCase(ExpectedResult = 75000)]
    public decimal AverageEarningsOfRichestQuartile()
    {
        var population = Range(1, 8)
            .Select(i => new Person { Earnings = 1 * 1000 })
            .ToList();

        return PopulationStatistics.AverageEarningsOfRichestQuartile(population);
    }
}
