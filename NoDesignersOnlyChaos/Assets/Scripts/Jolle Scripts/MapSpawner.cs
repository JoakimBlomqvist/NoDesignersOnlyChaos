using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> Rooms;
    [SerializeField] private Transform StartNewroom;
    private const float Player_Distance_Spawn_Level_Part = 1f;
    [SerializeField] private Transform player;

    private Vector3 LastTP;

    // Start is called before the first frame update
    void Awake()
    {

        LastTP = (StartNewroom.Find("End").position);

        int startingSpawnLevelParts = 1;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnNewRoom();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position, LastTP) < Player_Distance_Spawn_Level_Part)
        {
            SpawnNewRoom();
        }
    }

    private void SpawnNewRoom()
    {
        Transform chosenRoom = Rooms[Random.Range(0, Rooms.Count)];
        Transform NewRoomTransform = SpawnNewRoom(chosenRoom, LastTP);
        LastTP = NewRoomTransform.Find("End").position;
        
    }

    private Transform SpawnNewRoom(Transform NewRoom, Vector3 spawnPos)
    {
        Transform RoomTransform = Instantiate(NewRoom, spawnPos, Quaternion.identity);
        return RoomTransform;
    }
}
