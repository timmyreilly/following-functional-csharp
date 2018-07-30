//#r "..\..\LaYumba.Functional\bin\Debug\netstandard1.6\LaYumba.Functional.dll"
#r "LaYumba.Functional\bin\Debug\netstandard1.6\LaYumba.Functional.dll"
#r "LaYumba.Functional.Data\bin\Debug\netstandard1.6\LaYumba.Functional.Data.dll"

using LaYumba.Functional;
using static LaYumba.Functional.F;
using static System.Console;

var daysOfWeek = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().Select(d => d.ToString());

static Func<int, int, int> multiply = (i, j) => i * j;
static Func<int, int> @double = i => i * 2;


// Things to do in REPL as of 7/30

#r "System.Threading.Tasks"
#r "..\tireilly\GitHub\functional-csharp-code\LaYumba.Functional.Data\bin\Debug\netstandard1.6\LaYumba.Functional.Data.dll"
#r "..\tireilly\GitHub\functional-csharp-code\LaYumba.Functional\bin\Debug\netstandard1.6\LaYumba.Functional.dll"
using Unit = System.ValueTuple; 
using LaYumba.Functional; 
using static LaYumba.Functional.F; 


// Need to run all of the above in order ^ 




public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f) => ts.Select(f);
