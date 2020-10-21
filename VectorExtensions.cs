using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
	public static Vector3 ClampInBounds(this Vector3 current, Bounds bounds)
	{
		current = new Vector3(Mathf.Clamp(current.x, bounds.min.x, bounds.max.x),
							  Mathf.Clamp(current.y, bounds.min.y, bounds.max.y),
							  Mathf.Clamp(current.z, bounds.min.z, bounds.max.z));
		return current;
	}

	public static Vector2 ClampInRadius(this Vector2 newLocation, Vector2 centerPosition, float radius)
	{
		Vector2 delta = newLocation - centerPosition;
		float distance = delta.magnitude; 

		if (distance > radius)
		{
			newLocation = centerPosition + delta.normalized * radius;
		}
		return newLocation;
	}

	public static Vector2 Direction(this Vector2 localPosition, float radius = 1.0f)
	{
		var clamped = Vector2.ClampMagnitude(localPosition, radius);
		return clamped;
	}

	public static Vector3 Direction(this Vector3 localPosition, float radius = 1.0f)
	{
		var clamped = Vector3.ClampMagnitude(localPosition, radius);
		return clamped;
	}

	public static float MiddleValue(this Vector2 original)
	{
		float x = original.x;
		float y = original.y;
		return (x + y) / 2.0f;
	}

	public static Vector3 DirectionByCamera(this Vector2 current, Transform targetObject, Transform camera)
	{
		var localDirection = new Vector3(current.x, 0f, current.y);
		var cameraDirection = camera.TransformDirection(localDirection);
		var unitRotation = Quaternion.FromToRotation(camera.up, targetObject.up);
		var lookTarget = unitRotation * cameraDirection;
		return lookTarget;
	}

	public static Vector3 xy(this Vector3 current)
	{
		return new Vector3(current.x, current.y, 0);
	}

	public static Vector3 xz(this Vector3 current)
	{
		return new Vector3(current.x, 0, current.z);
	}

	public static Vector3 yz(this Vector3 current)
	{
		return new Vector3(0, current.y, current.z);
	}

	public static float Sum(this Vector3 current)
	{
		return (current.x + current.y + current.z);
	}

	public static Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
	{
		Vector3 P = x * Vector3.Normalize(B - A) + A;
		return P;
	}

	public static Vector3 NearestPointOnLine(this Vector3 pnt, Vector3 linePnt, Vector3 lineDir)
	{
		lineDir.Normalize();
		var v = pnt - linePnt;
		var d = Vector3.Dot(v, lineDir);
		return linePnt + lineDir * d;
	}

	public static float InverseLerp(this Vector3 value, Vector3 a, Vector3 b)
	{
		Vector3 AB = b - a;
		Vector3 AV = value - a;
		return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
	}
}
