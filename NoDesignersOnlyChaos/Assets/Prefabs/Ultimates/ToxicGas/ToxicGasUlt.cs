using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasUlt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem toxicGas;

    private void Start()
    {
        ParticleSystem toxicGas = GetComponent<ParticleSystem>();
        //toxicGas.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ToxicGasActiv());
        }
    }
    IEnumerator ToxicGasActiv()
    {

        toxicGas.Play();

        yield return new WaitForSeconds(5f);
        toxicGas.Stop();
    }
}
