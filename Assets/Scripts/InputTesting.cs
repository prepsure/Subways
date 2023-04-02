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


        // Use this for initialization
        void Update()
        {
            
        }
    }
}