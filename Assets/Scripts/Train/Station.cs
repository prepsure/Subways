using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    public int MaxPassengersWaiting;
    public float PassengersWaiting;

    public bool isDropOff;

    public float PassengerArrivalRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDropOff)
        {
            float passengersPerUpdate = Time.deltaTime * PassengerArrivalRate;

            PassengersWaiting += passengersPerUpdate;

            PassengersWaiting = Mathf.Min(PassengersWaiting, MaxPassengersWaiting);
        }
    }

    public float PickUp(float pickupRate)
    {
        if (PassengersWaiting < Time.deltaTime * pickupRate)
        {
            return 0;
        }

        float passengersPickedUp = Time.deltaTime * pickupRate;
        PassengersWaiting -= passengersPickedUp;

        return passengersPickedUp;
    }

    public float DropOff(float dropOffRate)
    {
        float passengersDroppedOff = Time.deltaTime * dropOffRate;
        PassengersWaiting += passengersDroppedOff;

        return passengersDroppedOff;
    }
}
