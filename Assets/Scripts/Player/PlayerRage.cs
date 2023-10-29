using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerShoot),typeof(PlayerBoost),typeof(Player))]
public class PlayerRage : MonoBehaviour
{
    [SerializeField] private float RageTime;
    private void InitRage()
    {
        GetComponent<PlayerShoot>().enabled = false;
        GetComponent<PlayerBoost>().enabled = false;
    }
    private void RageShoot()
    {

    }
    private void EndRage() 
    {
        GetComponent<PlayerShoot>().enabled = true;
        GetComponent<PlayerBoost>().enabled = true;
    }
    public IEnumerator Rage()
    {
        InitRage();
        for (float i=0; i < RageTime; i += 0.1f) 
        {
            yield return new WaitForSeconds(0.1f);
        }
        EndRage();
    }
}
