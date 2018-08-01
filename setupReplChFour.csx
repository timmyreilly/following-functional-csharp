#r "System.Threading.Tasks"
#r "LaYumba.Functional.Data\bin\Debug\netstandard1.6\LaYumba.Functional.Data.dll"
#r "LaYumba.Functional\bin\Debug\netstandard1.6\LaYumba.Functional.dll"
using Unit = System.ValueTuple;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using static System.Console;


public struct Age
{
    private int Value { get; }
    private Age(int value)
    {
        if (!IsValid(value))
            throw new ArgumentException($"{value} is not a valid age");

        Value = value;
    }

    private static bool IsValid(int age)
       => 0 <= age && age < 120;

    public static Option<Age> Of(int age)
       => IsValid(age) ? Some(new Age(age)) : None;

    public static bool operator <(Age l, Age r) => l.Value < r.Value;
    public static bool operator >(Age l, Age r) => l.Value > r.Value;

    public static bool operator <(Age l, int r) => l < new Age(r);
    public static bool operator >(Age l, int r) => l > new Age(r);

    public override string ToString() => Value.ToString();
}

public static class AskForValidAgeAndPrintFlatteringMessage
{
    public static void _main()
       => WriteLine($"Only {ReadAge()}! That's young!");

    static Option<Age> ParseAge(string s)
       => Int.Parse(s).Bind(Age.Of);

    static Age ReadAge()
       => ParseAge(Prompt("Please enter your age")).Match(
          () => ReadAge(),
          (age) => age);

    static string Prompt(string prompt)
    {
        WriteLine(prompt);
        return ReadLine();
    }
}

bool IsNatural(int i) => i >= 0; 
Option<int> ToNatural(string s) => Int.Parse(s).Where(IsNatural); 

/*
// #r "..\tireilly\GitHub\functional-csharp-code\LaYumba.Functional.Data\bin\Debug\netstandard1.6\LaYumba.Functional.Data.dll"
// #r "..\tireilly\GitHub\functional-csharp-code\LaYumba.Functional\bin\Debug\netstandard1.6\LaYumba.Functional.dll"



 */