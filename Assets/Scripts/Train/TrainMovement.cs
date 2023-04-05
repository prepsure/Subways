using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public GameObject StartCurve;

    public Vector3 IdealTurningDirection = Vector2.zero;
    public float MaxTravelSpeed = 8;

    public float TravelSpeed = 1;
    public float TravelDirection = 1;

    private ICurveBase _currentCurve;
    private float _tOnCurrentCurve = 0;

    bool Started = false;

    const float MAX_CURVE_JUMP_DISTANCE = 0.2f;

    // Start is called before the first frame update
    public void StartChuggin()
    {
        bool got = StartCurve.TryGetComponent(out ICurveBase curve);
        Debug.Assert(got);
        PositionOnCurve(curve, _tOnCurrentCurve, TravelDirection);
        _currentCurve = curve;
        Started = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started)
        {
            return;
        }

        _tOnCurrentCurve += Time.deltaTime * TravelDirection * TravelSpeed / Bezier.GetLength(_currentCurve);
        PositionOnCurve(_currentCurve, _tOnCurrentCurve, TravelDirection);

        if (AtJunction())
        {
            _tOnCurrentCurve = Mathf.Clamp(_tOnCurrentCurve, 0, 1);
            PositionOnCurve(_currentCurve, _tOnCurrentCurve, TravelDirection);

            // TODO change curve candidate based on player controls
            Debug.Log(IdealTurningDirection);
            _currentCurve = PickClosestInDirectionOnXZ(
                IdealTurningDirection,
                FindNextCurveCandidates(-GetEndPointDirectionIn(_currentCurve, _tOnCurrentCurve))
            );
            TravelDirection = GetTravelDirectionFromClosestEndPoint(_currentCurve);
            _tOnCurrentCurve = OneAround0To0To1(-TravelDirection);
        }

        PositionOnCurve(_currentCurve, _tOnCurrentCurve, TravelDirection);
    }

    bool AtJunction()
    {
        return _tOnCurrentCurve < 0 || _tOnCurrentCurve > 1;
    }

    void PositionOnCurve(ICurveBase curve, float t, float dir)
    {
        Vector3 position = curve.GetPoint(curve.DistanceToT(t));
        transform.localPosition = position;
        transform.LookAt(position + dir * curve.GetDirection(curve.DistanceToT(t)), Vector3.up + IdealTurningDirection / 2f);
    }

    List<ICurveBase> FindNextCurveCandidates(Vector3 outDirection)
    {
        List<ICurveBase> ALL_CURVES = FindObjectsOfType<MonoBehaviour>().OfType<ICurveBase>().ToList();

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

    Vector3 GetEndPointDirectionIn(ICurveBase curve, float endPoint)
    {
        if (endPoint < 0.5)
        {
            return curve.GetDirection(endPoint);
        }
        return -curve.GetDirection(endPoint);
    }

    Vector3 GetEndPointTrackDirectionIn(ICurveBase curve, float endPoint)
    {
        // dt so we dont get the direction directly at the end (which will probably be 0)
        float dt = 0.01f;

        if (endPoint < 0.5)
        {
            return curve.GetDirection(endPoint + dt);
        }

        // if its at the end, to go in we reverse the direction
        return -curve.GetDirection(endPoint - dt);
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

    public ICurveBase PickClosestInDirectionOnXZ(Vector3 target, List<ICurveBase> candidates)
    {
        ICurveBase bestSoFar = candidates[0];

        foreach (ICurveBase curve in candidates)
        {
            Vector3 xz1 = GetClosestEndpointTrackDirectionInNormalizedXZ(curve);
            Vector3 xz2 = GetClosestEndpointTrackDirectionInNormalizedXZ(bestSoFar);

            if (Vector3.Dot(xz1, target) > Vector3.Dot(xz2, target))
            {
                bestSoFar = curve;
            }
        }

        return bestSoFar;
    }

    Vector3 GetClosestEndpointTrackDirectionInNormalizedXZ(ICurveBase curve)
    {
        Vector3 inDirection = GetEndPointTrackDirectionIn(curve, GetClosestEndPoint(curve));
        Vector3 xz = Vector3.Normalize(Vector3.Scale(Vector3.one - Vector3.up, inDirection));
        return xz;
    }

    float OneAround0To0To1(float t)
    {
        return t / 2 + 0.5f;
    }
}
