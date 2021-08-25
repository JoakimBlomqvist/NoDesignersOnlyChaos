using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapGenerator : MonoBehaviour
{
    public GameObject[,] minimapArray;
    private MapGenerator _mapGenerator;
    private int gridX;
    private int gridY;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private GameObject prefab;
    private Image image;
    private Vector2 pastVector2;
    public void Init(MapGenerator mapGenerator)
    {
        gridX = mapGenerator.gridX;
        gridY = mapGenerator.gridY;
        minimapArray = new GameObject[gridX, gridY];
        GenerateMiniMap();
    }

    private void GenerateMiniMap()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                 
                 minimapArray[x, y] = Instantiate(prefab,new Vector3(parentTransform.position.x + x * 20, parentTransform.position.y + y * 20), Quaternion.identity, parentTransform);
                 minimapArray[x, y].GetComponent<Image>().color = new Color(0, 1, 0);
            }
        }
        
    }

    public void UpdateMiniMap(Vector2 vector2)
    {
        int x = Convert.ToInt32(vector2.x);
        int y = Convert.ToInt32(vector2.y);
        if (pastVector2.y < vector2.y)
        {
            minimapArray[x,y - 1].GetComponent<Image>().color = new Color(1, 0, 0);
        }
        else if (pastVector2.x < vector2.x)
        {
            minimapArray[x - 1,y].GetComponent<Image>().color = new Color(1, 0, 0);
        }
        else if (pastVector2.x > vector2.x)
        {
            minimapArray[x + 1,y].GetComponent<Image>().color = new Color(1, 0, 0);
        }
        else if (pastVector2.y > vector2.y)
        {
            minimapArray[x,y + 1].GetComponent<Image>().color = new Color(1, 0, 0);
        }
        minimapArray[x,y].GetComponent<Image>().color = new Color(1, 1, 0);
        pastVector2 = vector2;
    }
}
