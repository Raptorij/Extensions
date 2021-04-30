using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlider : Slider
{
	public System.Action<PointerEventData> pointerEnter;
	public System.Action<PointerEventData> pointerDown;
	public System.Action<PointerEventData> pointerUp;
	public System.Action<PointerEventData> pointerExit;

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		pointerEnter?.Invoke(eventData);
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		pointerDown?.Invoke(eventData);
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		pointerUp?.Invoke(eventData);
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		pointerExit?.Invoke(eventData);
	}
}
