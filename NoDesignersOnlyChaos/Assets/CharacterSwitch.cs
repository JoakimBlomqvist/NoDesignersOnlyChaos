using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitch : MonoBehaviour
{
    [SerializeField] SpriteHolder spriteholder;
    

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = spriteholder.characterCurrentSprite;
    }

}
