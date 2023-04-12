using Assets.Scripts.Train;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class Countdown : MonoBehaviour
    {

        public TextMeshProUGUI UIPrefab;

        private TextMeshProUGUI _count;
        private float _timer = 180;

        // Use this for initialization
        void Start()
        {
            _count = Instantiate(UIPrefab, FindObjectOfType<Canvas>().transform);
            _count.fontSize = 50;
            _count.color = Color.Lerp(Color.red, Color.white, 0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            _count.GetComponent<RectTransform>().anchorMin = new(0.5f, 1f);
            _count.GetComponent<RectTransform>().anchorMax = new(0.5f, 1f);
            _count.GetComponent<RectTransform>().pivot = new(0.5f, 1f);

            _timer -= Time.deltaTime;

            _count.text = (Mathf.Round(_timer*10)).ToString();

            if (_timer < 0)
            {
                _count.fontSize = 100;
                _count.color = Color.red;

                _count.GetComponent<RectTransform>().anchorMin = new(0.5f, 0.5f);
                _count.GetComponent<RectTransform>().anchorMax = new(0.5f, 0.5f);
                _count.GetComponent<RectTransform>().pivot = new(0.5f, 0.5f);

                _count.text = "DONE";

                Time.timeScale = 0;
            }
        }
    }
}