using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentExtensions
{
	public static void SetObjectActive(this Component target, bool activate)
	{
		target.gameObject.SetActive(activate);
	}
}
