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
            new Vector2(0, 320),
            new Vector2(0, 120),
            new Vector2(0, -80),
            new Vector2(0, -280),
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
            //_passengerCount.color = Color.Lerp(_trainStats.gameObject.GetComponent<Renderer>().materials[0].color, Color.white, 0.5f);

            _score = Instantiate(UIPrefab, FindObjectOfType<Canvas>().transform);
            _score.fontSize = 130;
            //_score.color = Color.Lerp(_trainStats.gameObject.GetComponent<Renderer>().materials[0].color, Color.white, 0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            _score.GetComponent<RectTransform>().anchoredPosition = playerPos[PlayerNum];
            _score.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
            _score.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0.5f);
            _score.GetComponent<RectTransform>().pivot = new Vector2(0, 0.5f);

            _passengerCount.GetComponent<RectTransform>().anchoredPosition = _mainCamera.WorldToScreenPoint(transform.position);
            _passengerCount.text = ((int)_trainStats.CurrentPassengers).ToString();

            _score.text = ((int)_trainStats.Score).ToString();
        }
    }
}