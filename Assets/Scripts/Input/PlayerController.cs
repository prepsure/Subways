using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int PlayerNumber;
    public Color PlayerColor;

    private Dictionary<int, Color> playerColors = new()
    {
        { 0, new Color(0.81f, 0.44f, 1) },
        { 1, new Color(1, 0.68f, 0.32f) },
        { 2, new Color(0.51f, 0.87f, 1) },
        { 3, new Color(0.61f, 1, 0.48f) },
    };

    // Start is called before the first frame update
    void Awake()
    {
        PlayerNumber = FindObjectOfType<PlayerRegistry>().RegisterPlayer(gameObject);
        PlayerColor = playerColors[PlayerNumber];
        gameObject.name = "Player" + (PlayerNumber);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        FindObjectOfType<PlayerRegistry>().DeregisterPlayer(PlayerNumber);
    }

    void OnStartButton()
    {
        if (SceneManager.GetActiveScene().name != "TitleScreen")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            return;
        }

        StartCoroutine(ChangeScenes());
    }

    IEnumerator ChangeScenes()
    {
        SceneManager.LoadScene("Instructions_1", LoadSceneMode.Single);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Instructions_2", LoadSceneMode.Single);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("TestRails", LoadSceneMode.Single);
    }
}
