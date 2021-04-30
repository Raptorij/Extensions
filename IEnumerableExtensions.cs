
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public static class IEnumerableExtensions
{
    public static T GetRandom<T>(this List<T> source)
    {
        return source[Random.Range(0, source.Count)];
    }

    public static int GetRandomIndex<T>(this List<T> source)
    {
        return Random.Range(0, source.Count);
    }

	// сорян, но это было прям не оч
	// НЕПРОЩУ и поч?
    // там другой код был жеж, он каждый IEnumerable в массив клонировал
	public static T GetRandom<T>(this IEnumerable<T> source)
	{
		int count = source.Count();
		int index = new System.Random().Next(0, count);
		return source.ElementAt(index);
	}
}
