using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoolText : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI text;
    [SerializeField]private string appearingText;
    private bool coroutineStarted;
    private IEnumerator _coroutine;

    private void Start()
    {
        _coroutine = ShowText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!coroutineStarted)
            {
                StartCoroutine(_coroutine);
            }
        }
    }
    

    private IEnumerator ShowText()
    {
        coroutineStarted = true;
        for (int i = 0; i < appearingText.Length; i++)
        {
            text.text = text.text + appearingText[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(7f);
        text.text = "";
    }
}
