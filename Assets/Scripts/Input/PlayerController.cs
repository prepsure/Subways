using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int PlayerNumber;
    public Color PlayerColor;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerNumber = FindObjectOfType<PlayerRegistry>().RegisterPlayer(gameObject);
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
        SceneManager.LoadScene("Train_Rails_v02", LoadSceneMode.Single);
    }
}
