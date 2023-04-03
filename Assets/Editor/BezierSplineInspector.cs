using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierSpline))]
public class BezierSplineInspector : Editor {

	private const int stepsPerCurve = 10;
	private const float directionScale = 0.5f;
	private const float handleSize = 0.04f;
	private const float pickSize = 0.06f;

	public static readonly Color BEZIER_COLOR = Color.white;

	private static Color[] modeColors = {
		Color.magenta,
		Color.yellow,
		Color.cyan
	};

	private BezierSpline spline;
	private Transform handleTransform;
	private Quaternion handleRotation;
	private int selectedIndex = -1;

	public override void OnInspectorGUI () {
		spline = target as BezierSpline;
		EditorGUI.BeginChangeCheck();
		bool loop = EditorGUILayout.Toggle("Loop", spline.Loop);
		if (EditorGUI.EndChangeCheck()) {
			Undo.RecordObject(spline, "Toggle Loop");
			EditorUtility.SetDirty(spline);
			spline.Loop = loop;
		}
		if (selectedIndex >= 0 && selectedIndex < spline.ControlPointCount) {
			DrawSelectedPointInspector();
		}
		if (GUILayout.Button("Add Curve")) {
			Undo.RecordObject(spline, "Add Curve");
			spline.AddCurve();
			EditorUtility.SetDirty(spline);
		}
	}

	private void DrawSelectedPointInspector() {
		GUILayout.Label("Selected Point");
		EditorGUI.BeginChangeCheck();
		Vector3 point = EditorGUILayout.Vector3Field("Position", spline.GetControlPoint(selectedIndex));
		if (EditorGUI.EndChangeCheck()) {
			Undo.RecordObject(spline, "Move Point");
			EditorUtility.SetDirty(spline);
			spline.SetControlPoint(selectedIndex, point);
		}
		EditorGUI.BeginChangeCheck();
		BezierControlPointMode mode = (BezierControlPointMode)EditorGUILayout.EnumPopup("Mode", spline.GetControlPointMode(selectedIndex));
		if (EditorGUI.EndChangeCheck()) {
			Undo.RecordObject(spline, "Change Point Mode");
			spline.SetControlPointMode(selectedIndex, mode);
			EditorUtility.SetDirty(spline);
		}
	}

	private void OnSceneGUI () {
		spline = target as BezierSpline;
		handleTransform = spline.transform;
		handleRotation = Tools.pivotRotation == PivotRotation.Local ?
			handleTransform.rotation : Quaternion.identity;
		
		Vector3 p0 = ShowPoint(0);
		for (int i = 1; i < spline.ControlPointCount; i += 3) {
			Vector3 p1 = ShowPoint(i);
			Vector3 p2 = ShowPoint(i + 1);
			Vector3 p3 = ShowPoint(i + 2);
			
			Handles.color = Color.gray;
			Handles.DrawLine(p0, p1);
			Handles.DrawLine(p2, p3);
			
			Handles.DrawBezier(p0, p3, p1, p2, BEZIER_COLOR, null, 2f);
			p0 = p3;
		}

		ShowAllLines();
		//ShowDirections();
	}

	private void ShowDirections () {
		Handles.color = Color.green;
		Vector3 point = spline.GetPoint(0f);
		Handles.DrawLine(point, point + spline.GetDirection(0f) * directionScale);
		int steps = stepsPerCurve * spline.CurveCount;
		for (int i = 1; i <= steps; i++) {
			point = spline.GetPoint(i / (float)steps);
			Handles.DrawLine(point, point + spline.GetDirection(i / (float)steps) * directionScale);
		}
	}

	private Vector3 ShowPoint (int index) {
		Vector3 point = handleTransform.TransformPoint(spline.GetControlPoint(index));
		float size = HandleUtility.GetHandleSize(point);
		if (index == 0) {
			size *= 2f;
		}
		Handles.color = modeColors[(int)spline.GetControlPointMode(index)];
		if (Handles.Button(point, handleRotation, size * handleSize, size * pickSize, Handles.DotHandleCap)) {
			selectedIndex = index;
			Repaint();
		}
		if (selectedIndex == index) {
			EditorGUI.BeginChangeCheck();
			point = Handles.DoPositionHandle(point, handleRotation);
			if (EditorGUI.EndChangeCheck()) {
				Undo.RecordObject(spline, "Move Point");
				EditorUtility.SetDirty(spline);
				spline.SetControlPoint(index, handleTransform.InverseTransformPoint(point));
			}
		}
		return point;
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

				Handles.DrawBezier(p0, p3, p1, p2, BEZIER_COLOR, null, 2f);

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

			Handles.DrawBezier(p0, p3, p1, p2, BEZIER_COLOR, null, 2f);
		}

		foreach (Line line in allCurves.Where(c => c is Line))
		{
			Transform handleTransform = line.transform;
			Vector3 p0 = handleTransform.TransformPoint(line.p0);
			Vector3 p1 = handleTransform.TransformPoint(line.p1);

			Handles.color = BEZIER_COLOR;
			Handles.DrawLine(p0, p1);
		}
	}
}