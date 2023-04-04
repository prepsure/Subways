using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    public PlayerRegistry playerRegistry;
    [SerializeField]
    public int PlayerSlot = 1;
    [SerializeField]
    public Color ActiveColor = new Color(81f / 256f, 1, 154f / 256f);
    [SerializeField]
    public Color InactiveColor = new Color(221f/256f, 221f / 256f, 221f / 256f);

    GameObject _status;

    // Start is called before the first frame update
    void Start()
    {
        _status = transform.Find("Status").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRegistry.PlayersJoined.Length >= PlayerSlot && playerRegistry.PlayersJoined[PlayerSlot - 1] != null)
        {
            _status.GetComponent<Image>().color = ActiveColor;
        } 
        else
        {
            _status.GetComponent<Image>().color = InactiveColor;
        }
    }
}
