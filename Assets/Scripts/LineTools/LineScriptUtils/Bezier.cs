using UnityEngine;

public static class Bezier {

	public static float GetLength(ICurveBase curve)
    {
		const float INCREMENT = 0.01f;
		float len = 0;

		for (float t = 0; t < 1; t += INCREMENT)
        {
			len += Vector3.Magnitude(curve.GetPoint(t + INCREMENT) - curve.GetPoint(t));
        }

		return len;
    }

	public static float[] MakeDistanceToTMap(ICurveBase curve)
	{
		float curveLen = GetLength(curve);
		int totalSlots = (int)Mathf.Ceil(curveLen * ICurveBase.SEGMENTS_PER_UNIT);
		float[] distToTMap = new float[totalSlots];

		float t = 0;
		float foundD = 0;

		for (int slot = 0; slot < totalSlots; slot++)
		{
			float d = slot / (float)totalSlots * curveLen;

			while (foundD < d)
            {
				Vector3 v1 = curve.GetPoint(t);
				Vector3 v2 = curve.GetPoint(t + 1f/totalSlots);
				foundD += (v1 - v2).magnitude;

				t += 1f / totalSlots;
			}

			distToTMap[slot] = t;
		}

		return distToTMap;
	}

	public static Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, float t) {
		t = Mathf.Clamp01(t);
		float oneMinusT = 1f - t;
		return
			oneMinusT * oneMinusT * p0 +
			2f * oneMinusT * t * p1 +
			t * t * p2;
	}

	public static Vector3 GetFirstDerivative (Vector3 p0, Vector3 p1, Vector3 p2, float t) {
		return
			2f * (1f - t) * (p1 - p0) +
			2f * t * (p2 - p1);
	}

	public static Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
		t = Mathf.Clamp01(t);
		float OneMinusT = 1f - t;
		return
			OneMinusT * OneMinusT * OneMinusT * p0 +
			3f * OneMinusT * OneMinusT * t * p1 +
			3f * OneMinusT * t * t * p2 +
			t * t * t * p3;
	}

	public static Vector3 GetFirstDerivative (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) {
		t = Mathf.Clamp01(t);
		float oneMinusT = 1f - t;
		return
			3f * oneMinusT * oneMinusT * (p1 - p0) +
			6f * oneMinusT * t * (p2 - p1) +
			3f * t * t * (p3 - p2);
	}
}