using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;


public class CleardRooms : MonoBehaviour
{
    [SerializeField] private TMP_Text CleardRoomsText;
    RoomCurrency roomCurrency;
    private string rooms;
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        RoomCurrency.Instance.roomCounter.ToString(rooms);
        CleardRoomsText.text = rooms;
    }


}
