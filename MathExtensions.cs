using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtensions
{
	public static int RoundToInt(this float value)
	{
		return Mathf.RoundToInt(value);
	}

	public static bool IsBetween(this float number, float min, float max)
	{
		return number >= min && number <= max;
	}

	public static bool IsBetween(this int number, int min, int max)
	{
		return number >= min && number <= max;
	}

	public static int Fibonacci(int n)
	{
		return n > 1 ? Fibonacсi(n - 1) + Fibonacсi(n - 2) : n;
	}

	public static int Factorial(int x)
	{
		if (x == 0)
		{
			return 1;
		}
		else
		{
			return x * Factorial(x - 1);
		}
	}
}
