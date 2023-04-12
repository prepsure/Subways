using Assets.Scripts.Train;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class DisplayTrainPassengerCount : MonoBehaviour
    {

        public TextMeshProUGUI UIPrefab;
        public int PlayerNum = 0;

        private Vector3[] playerPos = new Vector3[]
        {
            Vector2.up,
            Vector2.one,
            Vector2.zero,
            Vector2.right,
        };

        private Camera _mainCamera;
        private TextMeshProUGUI _passengerCount;
        private TextMeshProUGUI _score;
        private TrainPassengers _trainStats;

        // Use this for initialization
        void Start()
        {
            _mainCamera = FindObjectOfType<Camera>();
            _trainStats = GetComponent<TrainPassengers>();

            _passengerCount = Instantiate(UIPrefab, FindObjectOfType<Canvas>().transform);
            _passengerCount.color = Color.Lerp(_trainStats.gameObject.GetComponent<Renderer>().materials[0].color, Color.white, 0.5f);

            _score = Instantiate(UIPrefab, FindObjectOfType<Canvas>().transform);
            _score.fontSize = 60;
            _score.color = Color.Lerp(_trainStats.gameObject.GetComponent<Renderer>().materials[0].color, Color.white, 0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            _score.GetComponent<RectTransform>().anchorMin = playerPos[PlayerNum];
            _score.GetComponent<RectTransform>().anchorMax = playerPos[PlayerNum];
            _score.GetComponent<RectTransform>().pivot = playerPos[PlayerNum];

            _passengerCount.GetComponent<RectTransform>().anchoredPosition = _mainCamera.WorldToScreenPoint(transform.position);
            _passengerCount.text = ((int)_trainStats.CurrentPassengers).ToString();

            _score.text = ((int)_trainStats.Score).ToString();
        }
    }
}