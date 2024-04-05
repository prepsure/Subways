using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int PlayerNumber;
    public Color PlayerColor;

    public string _initialSceneName;

    private Dictionary<int, Color> playerColors = new()
    {
        { 0, new Color(0x99/(float)0xFF, 0x34/(float)0xFF, 0xC1/(float)0xFF) },
        { 1, new Color(0xFE/(float)0xFF, 0x61/(float)0xFF, 0x00/(float)0xFF) },
        { 2, new Color(0x64/(float)0xFF, 0x8F/(float)0xFF, 0xFF/(float)0xFF) },
        { 3, new Color(0xDC/(float)0xFF, 0x26/(float)0xFF, 0x7F/(float)0xFF) },
    };

    private bool join1;
    private bool join2;

    // Update is called once per frame
    void OnDestroy()
    {
        FindObjectOfType<PlayerRegistry>().DeregisterPlayer(PlayerNumber);
    }

    void OnJoinAction1(InputValue value)
    {
        join1 = value.isPressed;
        Join();
    }

    void OnJoinAction2(InputValue value)
    {
        join2 = value.isPressed;
        Join();
    }

    void OnRestart(InputValue value)
    {
        if (value.isPressed)
        {
            foreach (var obj in FindObjectsOfType<GameObject>())
            {
                Destroy(obj);
            }

            SceneManager.LoadScene("JoinScreen");
        }
    }

    void Join()
    {
        if (!(join1 && join2))
        {
            return;
        }

        PlayerNumber = FindObjectOfType<PlayerRegistry>().RegisterPlayer(gameObject);
        PlayerColor = playerColors[PlayerNumber];
        gameObject.name = "Player" + (PlayerNumber);
        DontDestroyOnLoad(gameObject);

        _initialSceneName = SceneManager.GetActiveScene().name;
    }

    void OnStartButton()
    {
        Debug.Log("Start");

        if (SceneManager.GetActiveScene().name != _initialSceneName)
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            return;
        }

        //SceneManager.LoadScene("TrainRails", LoadSceneMode.Single);
        StartCoroutine(ChangeScenes());
    }

    IEnumerator ChangeScenes()
    {
        SceneManager.LoadScene("Instructions_1", LoadSceneMode.Single);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Instructions_2", LoadSceneMode.Single);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("TrainRails", LoadSceneMode.Single);
    }
}
