using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOrDoor : MonoBehaviour
{
    [SerializeField] private GameObject wall;

    public bool isClosed = false;
    // Start is called before the first frame update

    public void BlockPath(bool statement)
    {
        wall.SetActive(statement);
        isClosed = true;
    }

    public void PlayerEnterRoom()
    {
        wall.SetActive(true);
    }

    public void OpenDoor()
    {
        wall.SetActive(false);
    }
}
