using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRegistry : MonoBehaviour
{
    public GameObject[] PlayersJoined;

    void Awake()
    {
        PlayersJoined = new GameObject[GetComponent<PlayerInputManager>().maxPlayerCount];
        DontDestroyOnLoad(gameObject);
    }

    public int RegisterPlayer(GameObject player)
    {
        int empty = FindFirstEmpty(PlayersJoined);
        PlayersJoined[empty] = player;
        return empty;
    }

    public void DeregisterPlayer(int playerIndex)
    {
        PlayersJoined[playerIndex] = null;
    }

    int FindFirstEmpty(Object[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == null)
            {
                return i;
            }
        }

        return -1;
    }
}