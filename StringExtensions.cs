using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class StringExtensions
{
    public static int LevenshteinDistance(string source, string target)
    {
        if (string.IsNullOrEmpty(source))
        {
            if (string.IsNullOrEmpty(target)) return 0;
            return target.Length;
        }
        if (string.IsNullOrEmpty(target)) return source.Length;

        if (source.Length > target.Length)
        {
            var temp = target;
            target = source;
            source = temp;
        }

        var m = target.Length;
        var n = source.Length;
        var distance = new int[2, m + 1];

        for (var j = 1; j <= m; j++) distance[0, j] = j;

        var currentRow = 0;
        for (var i = 1; i <= n; ++i)
        {
            currentRow = i & 1;
            distance[currentRow, 0] = i;
            var previousRow = currentRow ^ 1;
            for (var j = 1; j <= m; j++)
            {
                var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
                distance[currentRow, j] = Mathf.Min(Mathf.Min(
                    distance[previousRow, j] + 1,
                    distance[currentRow, j - 1] + 1),
                    distance[previousRow, j - 1] + cost);
            }
        }
        return distance[currentRow, m];
    }

    public static string GetMostlyMatch(this string[] all, string compare)
    {
        List<int> matchList = new List<int>();
        foreach (string Track in all)
        {
            matchList.Add(LevenshteinDistance(Track, compare));
        }
        string match = all.ToList().ElementAt(matchList.IndexOf(matchList.Min()));
        return match;
    }
}
