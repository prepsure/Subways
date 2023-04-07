using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Train
{
    public class TrainPassengers : MonoBehaviour
    {
        public Station DropOffStation;

        public int MaxPassengers;
        public int CurrentPassengers;

        public int PassengerPickupRate;
        public int PassengerDropOffRate;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            /* if no dropoff station and near station
             *      dropoffstation = thisstation.destinationstation
             * 
             * if NearDropOffStation
             *     start dropping off passengers
             *  
             * if NearAnyStation and station.destinationstation == dropoffstation
             *      start pickingup passengers
             */
        }
    }
}