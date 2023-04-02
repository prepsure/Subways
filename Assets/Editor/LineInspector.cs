using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Line))]
public class LineInspector : Editor {

	private void OnSceneGUI () {

		Line line = target as Line;
		Transform handleTransform = line.transform;
		Vector3 p0 = handleTransform.TransformPoint(line.p0);
		Vector3 p1 = handleTransform.TransformPoint(line.p1);

		Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;


		Handles.color = Color.white;
		Handles.DrawLine(p0, p1);

		EditorGUI.BeginChangeCheck();
		p0 = Handles.DoPositionHandle(p0, handleRotation);
		if (EditorGUI.EndChangeCheck()) {
			Undo.RecordObject(line, "Move Point");
			EditorUtility.SetDirty(line);
			line.p0 = handleTransform.InverseTransformPoint(p0);
		}

		EditorGUI.BeginChangeCheck();
		p1 = Handles.DoPositionHandle(p1, handleRotation);
		if (EditorGUI.EndChangeCheck()) {
			Undo.RecordObject(line, "Move Point");
			EditorUtility.SetDirty(line);
			line.p1 = handleTransform.InverseTransformPoint(p1);
		}

		ShowAllLines();
	}

	private void ShowAllLines()
	{
		List<ICurveBase> allCurves = FindObjectsOfType<MonoBehaviour>().OfType<ICurveBase>().ToList();

		foreach (BezierSpline spline in allCurves.Where(c => c is BezierSpline))
		{
			Transform handleTransform = spline.transform;

			Vector3 p0 = handleTransform.TransformPoint(spline.GetControlPoint(0));
			for (int i = 1; i < spline.ControlPointCount; i += 3)
			{
				Vector3 p1 = handleTransform.TransformPoint(spline.GetControlPoint(i));
				Vector3 p2 = handleTransform.TransformPoint(spline.GetControlPoint(i + 1));
				Vector3 p3 = handleTransform.TransformPoint(spline.GetControlPoint(i + 2));

				Handles.DrawBezier(p0, p3, p1, p2, BezierSplineInspector.BEZIER_COLOR, null, 2f);

				p0 = p3;
			}
		}

		foreach (BezierCurve curve in allCurves.Where(c => c is BezierCurve))
		{
			Transform handleTransform = curve.transform;
			Vector3 p0 = handleTransform.TransformPoint(curve.points[0]);
			Vector3 p1 = handleTransform.TransformPoint(curve.points[1]);
			Vector3 p2 = handleTransform.TransformPoint(curve.points[2]);
			Vector3 p3 = handleTransform.TransformPoint(curve.points[3]);

			Handles.DrawBezier(p0, p3, p1, p2, BezierSplineInspector.BEZIER_COLOR, null, 2f);
		}

		foreach (Line line in allCurves.Where(c => c is Line))
		{
			Transform handleTransform = line.transform;
			Vector3 p0 = handleTransform.TransformPoint(line.p0);
			Vector3 p1 = handleTransform.TransformPoint(line.p1);

			Handles.color = BezierSplineInspector.BEZIER_COLOR;
			Handles.DrawLine(p0, p1);
		}
	}
}