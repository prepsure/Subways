using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class DisplayStationCount : MonoBehaviour
    {

        public TextMeshProUGUI UIPrefab;

        private Camera _mainCamera;
        private TextMeshProUGUI _count;
        private Station _stationStats;

        // Use this for initialization
        void Start()
        {
            _mainCamera = FindObjectOfType<Camera>();
            _count = Instantiate(UIPrefab, FindObjectOfType<Canvas>().transform);
            _stationStats = GetComponent<Station>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 screenPoint = _mainCamera.WorldToScreenPoint(transform.position);
            _count.GetComponent<RectTransform>().anchoredPosition = screenPoint;
            _count.text = ((int)_stationStats.PassengersWaiting).ToString();
        }
    }
}