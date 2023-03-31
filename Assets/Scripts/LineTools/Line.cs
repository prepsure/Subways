using UnityEngine;

public class Line : MonoBehaviour, ICurveBase {

	public Vector3 p0, p1;
	
	public Vector3 GetPoint(float t)
	{
		return transform.TransformPoint(Vector3.Lerp(p0, p1, t));
	}

	public Vector3 GetVelocity(float _)
	{
		return transform.TransformPoint(p1 - p0) - transform.position;
	}

	public Vector3 GetDirection(float t)
	{
		return GetVelocity(t).normalized;
	}
}