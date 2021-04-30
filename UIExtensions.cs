using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIExtensions
{
	public static void SetActive(this CanvasGroup canvasGroup, bool active)
	{
		canvasGroup.alpha = active ? 1 : 0;
		canvasGroup.interactable = active;
		canvasGroup.blocksRaycasts = active;
	}

	public static RenderTexture SetupRenderTexture(this RawImage rawImage, Camera camera)
	{
		var rectTransform = rawImage.GetComponent<RectTransform>();
		var sizeDelta = rectTransform.sizeDelta;
		var renderTexture = new RenderTexture(Mathf.CeilToInt(sizeDelta.x), Mathf.CeilToInt(sizeDelta.y), 16, RenderTextureFormat.ARGB32);
		renderTexture.antiAliasing = 2;
		rawImage.texture = camera.targetTexture = renderTexture;
		return renderTexture;
	}
}
