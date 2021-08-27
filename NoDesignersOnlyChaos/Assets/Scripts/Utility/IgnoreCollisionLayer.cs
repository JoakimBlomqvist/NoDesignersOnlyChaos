using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionLayer : MonoBehaviour
{
    [SerializeField] private int layer1;
    [SerializeField] private int layer2;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(layer1, layer2);
    }
}
