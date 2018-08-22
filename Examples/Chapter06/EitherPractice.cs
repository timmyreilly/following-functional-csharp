using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Math;
using LaYumba.Functional; 

namespace Examples.Chapter06
{
    using static F; 
    public class EitherPractice
    {
        Either<string, double> Calc(double x, double y)
        {
            if (y == 0) return "y cannot by 0"; 

            if( x != 0 && Sign(x) != Sign(y))
            {
                return "x / y cannot be negate"; 
            }

            return Sqrt(x / y); 
        }

    }
}
