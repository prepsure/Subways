using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public GameObject StartCurve;
    public float TravelSpeed = 1;
    public float TravelDirection = 1;

    private ICurveBase _currentCurve;
    private float _tOnCurrentCurve = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(StartCurve.TryGetComponent(out ICurveBase curve));
        PositionOnCurve(curve, _tOnCurrentCurve, TravelDirection);

        _currentCurve = curve;
    }

    // Update is called once per frame
    void Update()
    {
        _tOnCurrentCurve += Time.deltaTime * TravelDirection * TravelSpeed / Bezier.GetLength(_currentCurve);
        PositionOnCurve(_currentCurve, _tOnCurrentCurve, TravelDirection);

        if (_tOnCurrentCurve < 0 || _tOnCurrentCurve > 1)
        {
            _tOnCurrentCurve = Mathf.Clamp(_tOnCurrentCurve, 0, 1);
            PositionOnCurve(_currentCurve, _tOnCurrentCurve, TravelDirection);

            // TODO change curve candidate based on player controls
            _currentCurve = PickRandom(FindNextCurveCandidates());
            TravelDirection = GetTravelDirectionFromClosestEndPoint(_currentCurve);
            _tOnCurrentCurve = OneAround0To0To1(-TravelDirection);
        }

        PositionOnCurve(_currentCurve, _tOnCurrentCurve, TravelDirection);
    }

    void PositionOnCurve(ICurveBase curve, float t, float dir)
    {
        Vector3 position = curve.GetPoint(t);
        transform.localPosition = position;
        transform.LookAt(position + dir * curve.GetDirection(t));
    }

    List<ICurveBase> FindNextCurveCandidates()
    {
        List<ICurveBase> ALL_CURVES = FindObjectsOfType<MonoBehaviour>().OfType<ICurveBase>().ToList();
        const float MAX_CURVE_JUMP_DISTANCE = 1f;

        return ALL_CURVES
            .Where(c => 
            {
                return (c != _currentCurve) && (GetClosestEndPoint(c) < MAX_CURVE_JUMP_DISTANCE);
            })
            .ToList();
    }

    float GetClosestEndPoint(ICurveBase curve)
    {
        float startPointDisplacement = Vector3.Magnitude(curve.GetPoint(0) - transform.position);
        float endPointDisplacement = Vector3.Magnitude(curve.GetPoint(1) - transform.position);

        return (startPointDisplacement < endPointDisplacement) ? startPointDisplacement : endPointDisplacement;
    }

    float GetTravelDirectionFromClosestEndPoint(ICurveBase curve)
    {
        float startPointDisplacement = Vector3.Magnitude(curve.GetPoint(0) - transform.position);
        float endPointDisplacement = Vector3.Magnitude(curve.GetPoint(1) - transform.position);

        return (startPointDisplacement < endPointDisplacement) ? 1 : -1;
    }

    float OneAround0To0To1(float t)
    {
        return t / 2 + 0.5f;
    }

    T PickRandom<T>(List<T> list)
    {
        return list[Random.Range(0, list.Count())];
    }
}
