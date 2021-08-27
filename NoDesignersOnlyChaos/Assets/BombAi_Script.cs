using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAi_Script : MonoBehaviour
{
    private SpriteRenderer bomb;
    [SerializeField] private GameObject Bomb_Explosion;
    // Start is called before the first frame update
    private void Awake()
    {
        
        
        StartCoroutine(BombGoesBoom());
    }
    
    IEnumerator BombGoesBoom()
    {
        
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        Instantiate(Bomb_Explosion, gameObject.transform.position, Quaternion.identity);
        yield break;
    }
}
