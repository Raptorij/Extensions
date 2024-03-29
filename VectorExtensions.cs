﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
	public static Vector2 RandomPointOnCircle(float radius)
	{
		return Random.insideUnitCircle.normalized * radius;
	}
	public static Vector3 RandomPointOnSphere(float radius)
	{
		return Random.onUnitSphere * radius;
	}

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

	public static Vector3 ClampInRadius(this Vector3 newLocation, Vector3 centerPosition, float radius)
	{
		Vector3 delta = newLocation - centerPosition;
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

	public static float GetAngleFromVector(this Vector3 dir)
	{
		dir = dir.normalized;
		float n = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
		if (n < 0) n += 360;

		return n;
	}

	public static Vector3 ClampVector3(Vector3 vec, Vector3 min, Vector3 max)
	{
		return Vector3.Min(max, Vector3.Max(min, vec));
	}

	public static Vector3 GetHighlights(this Vector3 source)
	{
		float max = Mathf.NegativeInfinity;
		var result = Vector3.zero;
		if (Mathf.Abs(source.x) >= max)
		{
			max = Mathf.Abs(source.x);
			result = Vector3.right * Mathf.Sign(source.x);
		}
		if (Mathf.Abs(source.y) >= max)
		{
			max = Mathf.Abs(source.y);
			result = Vector3.up * Mathf.Sign(source.y);
		}
		if (Mathf.Abs(source.z) >= max)
		{
			max = Mathf.Abs(source.z);
			result = Vector3.forward * Mathf.Sign(source.z);
		}
		return result;
	}
}
