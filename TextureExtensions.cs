using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureExtensions
{
	public static Texture2D Invert(this Texture2D texture)
	{
		if (texture.isReadable)
		{
			var t = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false);
			for (int i = 0; i < t.width; i++)
			{
				for (int j = 0; j < t.height; j++)
				{
					var currentColor = texture.GetPixel(i, j);
					var targetColor = new Color(1.0f - currentColor.r, 1.0f - currentColor.g, 1.0f - currentColor.b, currentColor.a);
					t.SetPixel(i, j, targetColor);
				}
			}
			t.Apply();
			return t;
		}
		else
		{
			Debug.LogException(new System.Exception("Texture mast be Readable"));
			return null;
		}
	}

	public static Sprite GetSprite(this Texture2D tex)
	{
		var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
		return sprite;
	}

	public static Sprite GetSprite(this Texture2D tex, Sprite original)
	{
		var sprite = Sprite.Create(tex, new Rect(original.rect.x, original.rect.y, original.rect.width, original.rect.height), original.pivot, original.pixelsPerUnit);		
		return sprite;
	}
}
