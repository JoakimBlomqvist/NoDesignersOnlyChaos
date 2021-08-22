using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOrDoor : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    // Start is called before the first frame update

    public void ActivatePath()
    {
        wall.SetActive(false);
    }
}
