using UnityEngine;

public interface ICurveBase {

    const int SEGMENTS_PER_UNIT = 20;
    Vector3 GetPoint(float t);
    float DistanceToT(float d);
    Vector3 GetVelocity(float t);
    Vector3 GetDirection(float t);

}