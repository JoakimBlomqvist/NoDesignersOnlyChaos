using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCoordinates : MonoBehaviour
{
    public Vector2 coordinates;

    public void GetCoordinates(int x, int y)
    {
        coordinates = new Vector2(x, y);
    }
}
