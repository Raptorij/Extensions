using System;
using System.Collections.Generic;
public static class ListExtensions
{
	public static bool AddUnique<T>(this List<T> list, T item)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (Equals(list[i], item))
			{
				return false;
			}
		}
		list.Add(item);
		return true;
	}

	public static void RemoveAtSwapBack<T>(this List<T> list, int index)
	{
		var lastIndex = list.Count - 1;
		if (index == lastIndex)
		{
			list.RemoveAt(lastIndex);
		}
		else
		{
			list[index] = list[lastIndex];
			list.RemoveAt(lastIndex);
		}
	}

	public static bool RemoveSwapBack<T>(this List<T> list, T item)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (Equals(item, list[i]))
			{
				RemoveAtSwapBack(list, i);
				return true;
			}
		}
		return false;
	}

	public static bool AreAllSame<T>(this IEnumerable<T> enumerable)
	{
		if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

		using (var enumerator = enumerable.GetEnumerator())
		{
			var toCompare = default(T);
			if (enumerator.MoveNext())
			{
				toCompare = enumerator.Current;
			}

			while (enumerator.MoveNext())
			{
				if (toCompare != null && !toCompare.Equals(enumerator.Current))
				{
					return false;
				}
			}
		}

		return true;
	}
}
