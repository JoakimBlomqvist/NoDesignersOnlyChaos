using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCoordinates : MonoBehaviour
{
    public Vector2 coordinates;
    [SerializeField] private List<WallOrDoor> _wallOrDoors;
    
    public void GetCoordinates(int x, int y)
    {
        coordinates = new Vector2(x, y);

        if (x == 0 && y == 0)
        {
            _wallOrDoors[0].ActivatePath();
            _wallOrDoors[2].ActivatePath();
        }
        else if(x == 0 && y == MapGenerator.Instance.gridY - 1)
        {
            _wallOrDoors[1].ActivatePath();
            _wallOrDoors[2].ActivatePath();
        }
        else if (x == 0 && y < MapGenerator.Instance.gridY - 1)
        {
            _wallOrDoors[0].ActivatePath();
            _wallOrDoors[1].ActivatePath();
            _wallOrDoors[2].ActivatePath();
        }
        else if(x < MapGenerator.Instance.gridX - 1 && x > 0 && y < MapGenerator.Instance.gridY - 1 && y > 0)
        {
            _wallOrDoors[0].ActivatePath();
            _wallOrDoors[1].ActivatePath();
            _wallOrDoors[2].ActivatePath();
            _wallOrDoors[3].ActivatePath();
        }
        else if(y == 0 && x < MapGenerator.Instance.gridX - 1)
        {
            _wallOrDoors[0].ActivatePath();
            _wallOrDoors[2].ActivatePath();
            _wallOrDoors[3].ActivatePath();
        }
        else if (x == MapGenerator.Instance.gridX - 1 && y == 0)
        {
            _wallOrDoors[0].ActivatePath();
            _wallOrDoors[3].ActivatePath();
        }
        else if (x == MapGenerator.Instance.gridX - 1 && y == MapGenerator.Instance.gridY - 1)
        {
            _wallOrDoors[1].ActivatePath();
            _wallOrDoors[3].ActivatePath();
        }
        else if (x == MapGenerator.Instance.gridX - 1 && y > 0)
        {
            _wallOrDoors[0].ActivatePath();
            _wallOrDoors[1].ActivatePath();
            _wallOrDoors[3].ActivatePath();
        }
        else if (x > 0 && y == MapGenerator.Instance.gridY - 1)
        {
            _wallOrDoors[2].ActivatePath();
            _wallOrDoors[1].ActivatePath();
            _wallOrDoors[3].ActivatePath();
        }
    }
}
