using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Train
{
    public class TrainPassengers : MonoBehaviour
    {
        public Station DropOffStation;

        public int MaxPassengers;
        public float CurrentPassengers;

        public float PassengerPickupRate;
        public float PassengerDropOffRate;

        public float MaxPickUpDistance;

        public float Score;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Station closestStation = GetClosestStation();

            bool closeToStation = DistanceFrom(closestStation.gameObject, gameObject) <= MaxPickUpDistance;

            if (closeToStation && !closestStation.isDropOff)
            {
                // Pickup
                if (CurrentPassengers < MaxPassengers)
                {
                    float pickedUp = closestStation.PickUp(PassengerPickupRate);
                    CurrentPassengers += pickedUp;
                }
            } 
            else if (closeToStation && closestStation.isDropOff)
            {
                // Drop off
                if (CurrentPassengers > 0)
                {
                    float droppedOff = closestStation.DropOff(PassengerDropOffRate);
                    CurrentPassengers -= droppedOff;
                    Score += droppedOff;
                }
            }
        }

        Station GetClosestStation()
        {
            Station[] allStations = FindObjectsOfType<Station>();
            Station closest = allStations[0];

            foreach (Station s in FindObjectsOfType<Station>())
            {
                if (DistanceFrom(gameObject, s.gameObject) < DistanceFrom(gameObject, closest.gameObject))
                {
                    closest = s;
                }
            }

            return closest;
        }

        float DistanceFrom(GameObject a, GameObject b)
        {
            return Vector3.Magnitude(a.transform.position - b.transform.position);
        }

    }
}