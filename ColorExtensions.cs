using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtensions
{
	public static Color Hex(this string hex)
	{
		Color color;
		string h = "";
		if (hex.ToCharArray()[0] != '#')
		{
			h = "#" + hex;
		}
		else
		{
			h = hex;
		}

		if (h.Length == 7)
		{
			h += "FF";
		}

		if (ColorUtility.TryParseHtmlString(h, out color))
		{
			return color;
		}		
		Debug.LogException(new System.Exception("Wrong HEX format"));
		return Color.magenta;
	}

	public static string Hex(this Color color)
	{
		return "#" + ColorUtility.ToHtmlStringRGBA(color);
	}

	public static Color Invert(this Color color)
	{
		return new Color(1.0f - color.r, 1.0f - color.g, 1.0f - color.b, 1.0f);
	}
}
