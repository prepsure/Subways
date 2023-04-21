using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        { 0, new Color(0.81f, 0.44f, 1) },
        { 1, new Color(1, 0.68f, 0.32f) },
        { 2, new Color(0.51f, 0.87f, 1) },
        { 3, new Color(0.61f, 1, 0.48f) },
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
        if (SceneManager.GetActiveScene().name != _initialSceneName)
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            return;
        }

        SceneManager.LoadScene("TrainRails", LoadSceneMode.Single);
        //StartCoroutine(ChangeScenes());
    }

    IEnumerator ChangeScenes()
    {
        SceneManager.LoadScene("Instructions_1", LoadSceneMode.Single);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Instructions_2", LoadSceneMode.Single);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("TrainRails", LoadSceneMode.Single);
    }
}
