using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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
		if (enumerable == null) throw new System.ArgumentNullException(nameof(enumerable));

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

    public static List<T> GetShuffledList<T>(this List<T> sourceList)
    {
        var unshuffledList = new List<T>(sourceList);
        var shuffledList = new List<T>();
        while (unshuffledList.Count > 0)
        {
            var randomIndex = UnityEngine.Random.Range(0, unshuffledList.Count);
            shuffledList.Add(unshuffledList[randomIndex]);
            unshuffledList.RemoveAtSwapBack(randomIndex);
        }
        return shuffledList;
    }

    public static bool ContainsAny<T>(this List<T> list, List<T> match)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < match.Count; j++)
            {
                if (list[i].Equals(match[j]))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static int IndexOfByID<T>(this List<T> list, T obj) where T : Object
    {
        var id = obj.GetInstanceID();
        for (int i = 0; i < list.Count; i++)
        {
            if (id == list[i].GetInstanceID())
            {
                return i;
            }
        }
        return -1;
    }

    public static bool ContainsByID<T>(this List<T> list, T obj) where T : Object
    {
        var id = obj.GetInstanceID();
        for (int i = 0; i < list.Count; i++)
        {
            if (id == list[i].GetInstanceID())
            {
                return true;
            }
        }
        return false;
    }
    public static bool AddUniqueByID<T>(this List<T> list, T obj) where T : Object
    {
        var id = obj.GetInstanceID();
        for (int i = 0; i < list.Count; i++)
        {
            if (id == list[i].GetInstanceID())
            {
                return false;
            }
        }
        list.Add(obj);
        return true;
    }

    public static bool RemoveByID<T>(this List<T> list, T obj) where T : Object
    {
        var id = obj.GetInstanceID();
        for (int i = 0; i < list.Count; i++)
        {
            if (id == list[i].GetInstanceID())
            {
                list.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public static bool RemoveByIDSwapBack<T>(this List<T> list, T obj) where T : Object
    {
        var id = obj.GetInstanceID();
        for (int i = 0; i < list.Count; i++)
        {
            if (id == list[i].GetInstanceID())
            {
                list.RemoveAtSwapBack(i);
                return true;
            }
        }
        return false;
    }

    public static int RemoveAllByID<T>(this List<T> list, T obj) where T : Object
    {
        var id = obj.GetInstanceID();
        var count = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (id == list[i].GetInstanceID())
            {
                list.RemoveAt(i);
                count++;
                i--;
            }
        }
        return count;
    }

    public static T RandomItem<T>(this List<T> list)
    {
        if (list.Count == 0)
        {
            return default(T);
        }
        return list[Random.Range(0, list.Count)];
    }
    public static void Swap<T>(this List<T> array, int first, int second)
    {
        var temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }
    public static int CheckEmptyItems<T>(this List<T> list)
    {
        int removedCount = 0;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null)
            {
                list.RemoveAt(i);
                i--;
                removedCount++;
            }
        }
        return removedCount;
    }

    public static int RemoveAll<T>(this List<T> list, T item)
    {
        var removed = 0;
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (item.Equals(list[i]))
            {
                list.RemoveAt(i);
                removed++;
            }
        }
        return removed;
    }
    public static int RemoveAll<T>(this List<T> list, List<T> items)
    {
        var removed = 0;
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (items.Contains(list[i]))
            {
                list.RemoveAt(i);
                removed++;
            }
        }
        return removed;
    }

    public static bool Replace<T>(this List<T> list, T item, T replacement)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Equals(item))
            {
                list[i] = replacement;
                return true;
            }
        }
        return false;
    }

    public static T LastItem<T>(this List<T> list)
    {
        return list[^1];
    }
    
    public static bool CompareToOther<T>(this IEnumerable<T> source, IEnumerable<T> other)
    {
        bool result = true;
        result &= source.Count() == other.Count();
        if (result)
        {
            foreach (var item in source)
            {
                result &= other.Contains(item);
            }
        }

        return result;
    }
}
