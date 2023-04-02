using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts
{
    public class InputTesting : MonoBehaviour
    {
        void OnMove(InputValue val)
        {
            Debug.Log(gameObject.GetHashCode());
        }

        void OnSlowdown1(InputValue val)
        {
            Debug.Log(val.Get<float>());
        }

        void OnSlowdown2(InputValue val)
        {
            Debug.Log(val.Get<float>());
        }
    }
}