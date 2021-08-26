using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;



public class CleardRooms : MonoBehaviour
{
    [SerializeField] private TMP_Text CleardRoomsText;
    [SerializeField] TextMeshProUGUI leaderboardText;
    [SerializeField] private List<int> scoreList;
    
    // Start is called before the first frame update

    private void OnEnable()
    {
        scoreList.Add(RoomCurrency.Instance.roomCounter);

        CleardRoomsText.text = RoomCurrency.Instance.roomCounter.ToString();
        
        UpdateLeaderboardText();
        //EventManager.instance.OnUpdateleaderboard(scoreList);
    }

    void UpdateLeaderboardText()
    {
        int tempInt;
        TextMeshProUGUI temp = new TextMeshProUGUI();

        temp.text = string.Empty;

        for (int i = 0; i < scoreList.Count; i++)
        {
            for (int j = i + 1; j < scoreList.Count; j++)
            {
                Debug.Log(scoreList.Count);
                Debug.Log(scoreList[i] + "i:innan");
                Debug.Log(scoreList[j] + "j:innan");

                if (scoreList[j] > scoreList[i])
                {

                    tempInt = scoreList[i];
                    scoreList[i] = scoreList[j];
                    scoreList[j] = tempInt;

                    scoreList[i].ToString();
                    scoreList[j].ToString();


                }

                Debug.Log(scoreList[i] + "i");
                Debug.Log(scoreList[j] + "j");
            }
        }

        for (int i = 0; i < scoreList.Count; i++)
        {
            temp.text += (i + 1).ToString() + "st: ";
            temp.text += scoreList[i].ToString();
            temp.text += "\n";
        }

        leaderboardText.text = temp.text;

        
    }
}
