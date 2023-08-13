using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    public static void SetLayerRecursively(this GameObject go, int layerNumber)
    {
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }

	public static T GetChildComponentByName<T>(this Component origin, string name) where T : Component
	{
		foreach (T component in origin.GetComponentsInChildren<T>(true))
		{
			if (component.GetType().Name.ToLower() == name)
			{
				return component;
			}
		}
		return null;
	}

	public static bool TryGetChildComponent<T>(this Component origin, out T component) where T : Component
	{
		component = origin.GetComponentInChildren<T>();
		return component != null;
	}
}
