using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentExtensions
{
	public static void SetObjectActive(this Component target, bool activate)
	{
		target.gameObject.SetActive(activate);
	}

	public static bool TryGetComponentInChildren<T>(this GameObject target, out T component) where T : Component
	{
		component = target.GetComponentInChildren<T>();
		return component != null;
	}
}
