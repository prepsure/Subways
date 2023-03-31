using UnityEngine;

public interface ICurveBase {
    
    Vector3 GetPoint(float t);
    Vector3 GetVelocity(float t);
    Vector3 GetDirection(float t);

}