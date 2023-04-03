using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTesting : MonoBehaviour
{
    private float _speedMultiplier1 = 1;
    private float _speedMultiplier2 = 1;
    public float SpeedMultiplier
    {
        get
        {
            return (_speedMultiplier1 + _speedMultiplier2) / 2;
        }
    }

    void OnMove(InputValue val)
    {
        Debug.Log(gameObject.GetHashCode());
    }

    void OnSlowdown1(InputValue val)
    {
        _speedMultiplier1 = val.Get<float>();
    }

    void OnSlowdown2(InputValue val)
    {
        _speedMultiplier2 = val.Get<float>();
    }
}