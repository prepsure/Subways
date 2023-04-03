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
            _currentCurve = PickRandom(FindNextCurveCandidates(-GetEndPointDirectionIn(_currentCurve, _tOnCurrentCurve)));
            TravelDirection = GetTravelDirectionFromClosestEndPoint(_currentCurve);
            _tOnCurrentCurve = OneAround0To0To1(-TravelDirection);
        }

        PositionOnCurve(_currentCurve, _tOnCurrentCurve, TravelDirection);
    }

    void PositionOnCurve(ICurveBase curve, float t, float dir)
    {
        Vector3 position = curve.GetPoint(curve.DistanceToT(t));
        transform.localPosition = position;
        transform.LookAt(position + dir * curve.GetDirection(curve.DistanceToT(t)));
    }

    List<ICurveBase> FindNextCurveCandidates(Vector3 outDirection)
    {
        List<ICurveBase> ALL_CURVES = FindObjectsOfType<MonoBehaviour>().OfType<ICurveBase>().ToList();
        const float MAX_CURVE_JUMP_DISTANCE = 1f;

        return ALL_CURVES
            .Where(curve => 
            {
                int endPoint = GetClosestEndPoint(curve);
                float endPointDistance = Vector3.Magnitude(curve.GetPoint(endPoint) - transform.position);
                Vector3 inDirection = GetEndPointDirectionIn(curve, endPoint);
                return curve != _currentCurve
                    && endPointDistance < MAX_CURVE_JUMP_DISTANCE
                    && Vector3.Dot(outDirection, inDirection) > 0;
            })
            .ToList();
    }

    float GetClosestEndPointDistance(ICurveBase curve)
    {
        float startPointDisplacement = Vector3.Magnitude(curve.GetPoint(0) - transform.position);
        float endPointDisplacement = Vector3.Magnitude(curve.GetPoint(1) - transform.position);

        return (startPointDisplacement < endPointDisplacement) ? startPointDisplacement : endPointDisplacement;
    }

    Vector3 GetEndPointDirectionIn(ICurveBase curve, float endPoint)
    {
        if (endPoint < 0.5)
        {
            return curve.GetDirection(endPoint);
        }

        // if its at the end, to go in we reverse the direction
        return -curve.GetDirection(endPoint);
    }

    int GetClosestEndPoint(ICurveBase curve)
    {
        float startPointDisplacement = Vector3.Magnitude(curve.GetPoint(0) - transform.position);
        float endPointDisplacement = Vector3.Magnitude(curve.GetPoint(1) - transform.position);

        return (startPointDisplacement < endPointDisplacement) ? 0 : 1;
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
