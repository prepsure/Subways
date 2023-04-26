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
            //Time.timeScale = 0;
            _count = Instantiate(UIPrefab, FindObjectOfType<Canvas>().transform);
            _count.fontSize = 400;
            _count.color = Color.Lerp(Color.red, Color.white, 0.5f);
            _count.text = "180.00";

            _count.GetComponent<RectTransform>().sizeDelta = new Vector2(10000, 300);

            _count.GetComponent<RectTransform>().anchorMin = new(0.5f, 0.5f);
            _count.GetComponent<RectTransform>().anchorMax = new(0.5f, 0.5f);
            _count.GetComponent<RectTransform>().pivot = new(0.5f, 0.5f);

           // StartCoroutine(go());
        }


        IEnumerator go()
        {
            yield return new WaitForSecondsRealtime(0.3f);
            _count.GetComponent<TextMeshPro>().enabled = !_count.GetComponent<TextMeshPro>().enabled;
            yield return new WaitForSecondsRealtime(0.3f);
            _count.GetComponent<TextMeshPro>().enabled = !_count.GetComponent<TextMeshPro>().enabled;
            yield return new WaitForSecondsRealtime(0.3f);
            _count.GetComponent<TextMeshPro>().enabled = !_count.GetComponent<TextMeshPro>().enabled;
            yield return new WaitForSecondsRealtime(0.3f);
            _count.GetComponent<TextMeshPro>().enabled = !_count.GetComponent<TextMeshPro>().enabled;
            yield return new WaitForSecondsRealtime(0.3f);
            _count.GetComponent<TextMeshPro>().enabled = !_count.GetComponent<TextMeshPro>().enabled;
            yield return new WaitForSecondsRealtime(0.3f);
            _count.GetComponent<TextMeshPro>().enabled = true;
            Time.timeScale = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.timeScale == 0)
            {
                return;
            }

            _count.GetComponent<RectTransform>().anchorMin = new(0.5f, 1f);
            _count.GetComponent<RectTransform>().anchorMax = new(0.5f, 1f);
            _count.GetComponent<RectTransform>().pivot = new(0.5f, 1f);

            _timer -= Time.deltaTime;

            _count.text = _timer.ToString("F2");

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