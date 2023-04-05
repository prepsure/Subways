using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrainController : MonoBehaviour
{
    public GameObject TrainPrefab;
    private GameObject myTrain;

    private float _speedMultiplier1 = 1;
    private float _speedMultiplier2 = 1;
    public float SpeedMultiplier
    {
        get
        {
            return (_speedMultiplier1 + _speedMultiplier2) / 2;
        }
    }
    public Vector3 IdealWorldDirection = Vector3.zero;

    public GameObject MakeTrain()
    {
        myTrain = Instantiate(TrainPrefab);
        myTrain.GetComponent<Renderer>().materials[0].color = Random.ColorHSV();
        return myTrain;
    }

    void OnMove(InputValue val)
    {
        Vector2 rawInput = val.Get<Vector2>();

        IdealWorldDirection = FindObjectOfType<Camera>().transform
            .TransformDirection(new Vector3(rawInput.x, rawInput.y, 0));
    }

    void OnSlowdown1(InputValue val)
    {
        _speedMultiplier1 = 1 - val.Get<float>();
    }

    void OnSlowdown2(InputValue val)
    {
        _speedMultiplier2 = 1 - val.Get<float>();
    }

    private void Update()
    {
        if (myTrain == null)
        {
            return;
        }

        TrainMovement movement = myTrain.GetComponent<TrainMovement>();

        movement.TravelSpeed = movement.MaxTravelSpeed * SpeedMultiplier;
        movement.IdealTurningDirection = IdealWorldDirection;
    }
}