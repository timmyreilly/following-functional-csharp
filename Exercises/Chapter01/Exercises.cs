using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using LaYumba.Functional;
using static LaYumba.Functional.F;
namespace Exercises.Chapter1
{
    static class Exercises
    {
        // 1. Write a function that negates a given predicate: whenvever the given predicate
        // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
        static Func<T, bool> Negate<T>(this Func<T, bool> pred) => t => !pred(t);


        // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
        // rather than sorting it in place).

        static List<int> QuickSort(this List<int> list)
        {
            if (list.Count == 0) return new List<int>();

            var pivot = list[0];
            var rest = list.Skip(1);

            var small = from item in rest where item <= pivot select item;
            var large = from item in rest where pivot < item select item;

            return small.ToList().QuickSort()
                .Append(pivot)
                .Concat(large.ToList().QuickSort())
                .ToList(); 
        }



        // 3. Generalize your implementation to take a `List<T>`, and additionally a 
        // `Comparison<T>` delegate.

        static List<T> QuickSort<T>(this List<T> list, Comparison<T> compare)
        {
            if (list.Count == 0) return new List<T>();

            var pivot = list[0];
            var rest = list.Skip(1);

            var small = from item in rest where compare(item, pivot) <= 0 select item;
            var large = from item in rest where 0 < compare(item, pivot) select item;

            return small.ToList().QuickSort(compare)
                .Concat(new List<T> { pivot })
                .Concat(large.ToList().QuickSort(compare))
                .ToList(); 
        }

        // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
        // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
        // takes a `Func<IDisposable>` as first
        // parameter, instead of the `IDisposable`. (This can be used to fix warnings
        // given by some code analysis tools about instantiating an `IDisposable` and
        // not disposing it.)

        static R Using<TDisp, R>(Func<TDisp> createDisposable, Func<TDisp, R> func) where TDisp : IDisposable
        {
            using (var disp = createDisposable()) return func(disp); 
        }
    }
}
