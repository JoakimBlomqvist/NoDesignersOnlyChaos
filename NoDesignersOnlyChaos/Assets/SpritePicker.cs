using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePicker : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] SpriteHolder spriteHolder;

    public void ChangeCharacterSPrite()
    {
        spriteHolder.characterCurrentSprite = sprite;
    }
}
