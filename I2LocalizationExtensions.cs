using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace I2.Loc
{
	public static class I2LocalizationExtensions
	{
		public static string SetParam(this string original, string paramName, object paramValue)
		{
			string toFind = "{[" + paramName + "]}";
			original = original.Replace(toFind, paramValue.ToString());
			return original;
		}
	}
}