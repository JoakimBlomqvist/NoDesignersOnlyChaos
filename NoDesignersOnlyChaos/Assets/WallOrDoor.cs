using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOrDoor : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    // Start is called before the first frame update

    public void BlockPath(bool statement)
    {
        wall.SetActive(statement);
    }

    public void PlayerEnterRoom()
    {
        StartCoroutine(PlayerEnterDelay());
    }

    private IEnumerator PlayerEnterDelay()
    {
        wall.SetActive(true);
        yield return new WaitForSeconds(5f);
        wall.SetActive(false);
    }
}
