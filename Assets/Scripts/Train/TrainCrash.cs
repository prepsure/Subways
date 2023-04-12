using Assets.Scripts.UI;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Train
{
    public class TrainCrash : MonoBehaviour
    {
        public float IFrameSeconds = 2;
        public float ExplosionTime = 0.5f;

        private float _lastHit;

        public GameObject Explosion;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time < _lastHit + ExplosionTime)
            {
                return;
            }

            Explosion.SetActive(false);
        }

        private void OnTriggerStay(Collider other)
        {
            if (Time.time < _lastHit + IFrameSeconds)
            {
                return;
            }

            _lastHit = Time.time;

            Explode();
        }


        void Explode()
        {
            Debug.Log("hit!");
            FindObjectOfType<AudioSource>().Play();
            
            GetComponentInParent<TrainPassengers>().CurrentPassengers = 0;
            GetComponentInParent<TrainPassengers>().Score /= 2;

            Explosion.SetActive(true);
        }
    }
}