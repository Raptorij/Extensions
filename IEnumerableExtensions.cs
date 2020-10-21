
using System.Collections.Generic;
using System.Linq;

public static class IEnumerableExtensions
{
	public static T GetRandom<T>(this IEnumerable<T> source)
	{
		int count = source.Count();
		int index = new System.Random().Next(0, count);
		return source.ToArray()[index];
	}
}
