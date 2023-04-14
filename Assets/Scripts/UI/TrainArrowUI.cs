using Assets.Scripts.Train;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class TrainArrowUI : MonoBehaviour
    {

        public GameObject ArrowPrefab;

        private Camera _mainCamera;
        private GameObject _arrow;

        private Vector2 _maxSizeDelta;

        // Use this for initialization
        void Start()
        {
            _mainCamera = FindObjectOfType<Camera>();
            _arrow = Instantiate(ArrowPrefab, FindObjectOfType<Canvas>().transform);
            _maxSizeDelta = _arrow.GetComponent<RectTransform>().sizeDelta;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 screenPoint = _mainCamera.WorldToScreenPoint(transform.position);
            _arrow.GetComponent<RectTransform>().anchoredPosition = screenPoint;

            Vector2 turn = new(GetComponent<TrainMovement>().IdealTurningDirection.x, GetComponent<TrainMovement>().IdealTurningDirection.z);
            Quaternion rot = closestRotToDir(turn);
            _arrow.GetComponent<RectTransform>().rotation = rot;
            _arrow.GetComponent<RectTransform>().sizeDelta = new Vector2(turn.magnitude * _maxSizeDelta.x, _maxSizeDelta.y);
        }

        Quaternion closestRotToDir(Vector2 dir)
        {
            return Quaternion.Euler(90, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x));
        }
    }
}