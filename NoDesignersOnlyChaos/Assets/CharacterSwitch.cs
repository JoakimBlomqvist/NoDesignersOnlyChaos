using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwitch : MonoBehaviour
{
    [SerializeField] SpriteHolder spriteholder;
    [SerializeField] private Sprite[] Characters;
    [SerializeField] private Button[] characterbuttons;
    //[SerializeField] private SpriteRenderer spriteRender;
    public int characterindex;

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = spriteholder.characterCurrentSprite;
    }

    public void ChangeCharacter(int index)
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            
        }

        this.characterindex = index;
        spriteholder.characterCurrentSprite = Characters[index];
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
