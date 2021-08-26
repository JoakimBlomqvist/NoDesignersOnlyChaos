using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;


public class CleardRooms : MonoBehaviour
{
    [SerializeField] private TMP_Text CleardRoomsText;
    
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        CleardRoomsText.text = RoomCurrency.Instance.roomCounter.ToString();
        
    }


}
