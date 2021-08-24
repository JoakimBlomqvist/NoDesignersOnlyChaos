using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    #region Variables
    
    public int gridX = 10;
    public int gridY = 10;
    public float gapBetweenTilesY = 1.2f;
    public float gapBetweenTilesX = 1.2f;
    public GameObject defaultTile;
    public GameObject[] tileType;
    private Vector3 _postionOfTransform;
    private int _count = 0;
    [SerializeField] private Transform parent;
    [Header("BossRooms")]
    public GameObject[] bossRooms;

    [SerializeField] private int startBossSpawnAt = 2;
    [SerializeField] private int chanceOfBossRoom = 4;
    private int bossCount = 0;

    #endregion

    #region Singleton

    public static MapGenerator Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion

    private void Start()
    {
        GenerateMap();
    }

    //Generates the map. 
    public void GenerateMap()
    {
        _postionOfTransform = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        do
        {
            //For every column move the position of the first hexagon spawned 3/4 of the scale of the hexagon in the X-axis
            _postionOfTransform = new Vector3(transform.position.x + _count * gapBetweenTilesX * 1f, transform.position.y,
                transform.position.z);
            
            //For every 2nd column move the row half the hexagons scale in the Z-axis 
            if (_count % 2 == 0)
            {
                //_postionOfTransform.y += gapBetweenTiles * 1f;
            }
            
            GenerateRow();
            _count++;
            
        } while (_count < gridX); //While the count is less then the number of columns keep doing the loop
    }
    //Generates the row of hexagons
    private void GenerateRow()
    {
        for (int i = 0; i < gridY; i++)
        {
            _postionOfTransform.y += gapBetweenTilesY;

            int rand = Random.Range(0, chanceOfBossRoom);
            if (bossRooms.Length > bossCount && _count + i > startBossSpawnAt && rand == 0)
            {
                GameObject bossRoom = Instantiate(bossRooms[bossCount], _postionOfTransform, Quaternion.identity, parent);
                bossRoom.GetComponent<RoomCoordinates>().GetCoordinates(_count, i);

                bossCount++;
            }
            else
            {
                //Spawns a default tile in the row
                GameObject tile = Instantiate(tileType[Random.Range(0, tileType.Length)], _postionOfTransform, Quaternion.identity, parent);
                tile.GetComponent<RoomCoordinates>().GetCoordinates(_count, i);
            }
        }
    }
}
