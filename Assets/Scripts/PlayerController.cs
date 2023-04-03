using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int playerNum;

    // Start is called before the first frame update
    void Awake()
    {
        playerNum = FindObjectOfType<PlayerRegistry>().RegisterPlayer(gameObject);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        FindObjectOfType<PlayerRegistry>().DeregisterPlayer(playerNum);
    }
}
