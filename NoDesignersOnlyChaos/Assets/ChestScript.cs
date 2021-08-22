using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField]private GameObject chest;
    [SerializeField] private Transform Chest;
    [SerializeField] private GameObject[] chestLoot;
    EldKlotScript eldKlotScript;
    public bool EldklotContact = false;

    private void Start()
    {
        Chest = GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        eldKlotScript = collider.collider.GetComponent<EldKlotScript>();
        if(collider != null)
        {
            EldklotContact = true;
        }
    }
    private void Update()
    {
        if(EldklotContact == true)
        {
            StartCoroutine(DropItem());
            
        }
    }

    IEnumerator DropItem()
    {
        Destroy(chest);
        Instantiate(chestLoot[Random.Range(0, 10)], gameObject.transform.position, Quaternion.identity);

        yield break;
    }

}
