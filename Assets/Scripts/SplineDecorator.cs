using UnityEngine;

public class SplineDecorator : MonoBehaviour
{

	private BezierSpline spline;

	public int frequency;

	public bool lookForward;

	public Transform[] items;

	private void Awake()
	{
		spline = GetComponent<BezierSpline>();

		if (frequency <= 0 || items == null || items.Length == 0)
		{
			return;
		}
		float stepSize = frequency * items.Length;
		if (spline.Loop || stepSize == 1)
		{
			stepSize = 1f / stepSize;
		}
		else
		{
			stepSize = 1f / (stepSize - 1);
		}
		for (int p = 0, f = 0; f < frequency; f++)
		{
			for (int i = 0; i < items.Length; i++, p++)
			{
				Transform item = Instantiate(items[i]) as Transform;
				Vector3 position = spline.GetPoint(spline.DistanceToT(p * stepSize));
				item.transform.localPosition = position;
				if (lookForward)
				{
					item.transform.LookAt(position + spline.GetDirection(spline.DistanceToT(p * stepSize)));
				}
				item.transform.parent = transform;
			}
		}
	}
}