using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
	public static void ResetLocal(this Transform transform)
	{
		transform.localScale = Vector3.one;
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.identity;
	}

	public static void ResetWorld(this Transform transform)
	{
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
	}
}
