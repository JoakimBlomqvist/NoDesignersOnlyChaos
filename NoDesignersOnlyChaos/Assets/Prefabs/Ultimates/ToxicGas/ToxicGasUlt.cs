using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasUlt : UltimateAbility
{
    // Start is called before the first frame update
    [SerializeField] private GameObject toxicGas;
    
    public override void UseAbility()
    { 
        Debug.Log("ToxicGas");
        StartCoroutine(ToxicGasActive());
    }
    IEnumerator ToxicGasActive()
    {
        var gas = Instantiate(toxicGas, PlayerManager.Instance.playerPosition, Quaternion.identity);
        var gasParticleS = gas.GetComponent<ParticleSystem>();
        gasParticleS.Play();
        yield return new WaitForSeconds(5f);
        gasParticleS.Stop();
        Destroy(gas);
    }
}
