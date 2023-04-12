using Assets.Scripts.Train;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TrainArrowUI : MonoBehaviour
    {

        public GameObject ArrowPrefab;

        private Camera _mainCamera;
        private GameObject _arrow;

        // Use this for initialization
        void Start()
        {
            _mainCamera = FindObjectOfType<Camera>();
            _arrow = Instantiate(ArrowPrefab, FindObjectOfType<Canvas>().transform);
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 screenPoint = _mainCamera.WorldToScreenPoint(transform.position);
            _arrow.GetComponent<RectTransform>().anchoredPosition = screenPoint;
            _arrow.transform.LookAt(_mainCamera.transform.TransformDirection(GetComponent<TrainMovement>().IdealTurningDirection) + _arrow.transform.position);
        }
    }
}