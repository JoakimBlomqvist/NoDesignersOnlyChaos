using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_mage : MonoBehaviour
{
    [SerializeField] private float speed;
    private float waitTime;
    public float StartWaitTime;
    [SerializeField] private GameObject GhostAI;
    public Transform[] PatrolSpots;
    private int randomSpot;

    private void Start()
    {
        waitTime = StartWaitTime;
        randomSpot = Random.Range(0, PatrolSpots.Length);
    }
    private void OnDisable()
    {
        if(GhostAI != null)
        Instantiate(GhostAI, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PatrolSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, PatrolSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, PatrolSpots.Length);
                waitTime = StartWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    


}
