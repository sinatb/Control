using UnityEngine;
using System.Collections;
[RequireComponent(typeof(PlayerShoot),typeof(PlayerBoost),typeof(Player))]
public class PlayerRage : MonoBehaviour
{
    [SerializeField] private float RageTime;
    [SerializeField] private GameObject Gun;
    public delegate void OnRageEnd();
    public static event OnRageEnd onRageEnd;
    private void InitRage()
    {
        GetComponent<PlayerShoot>().enabled = false;
        GetComponent<PlayerBoost>().enabled = false;
        Gun.SetActive(false);
        Debug.Log("Rage init done");
    }
    private void RageShoot()
    {
        Debug.Log("Shoot");
    }
    private void EndRage() 
    {
        GetComponent<PlayerShoot>().enabled = true;
        GetComponent<PlayerBoost>().enabled = true;
        Gun.SetActive(true);
        Debug.Log("Rage Done");
    }
    public IEnumerator Rage()
    {
        InitRage();
        for (float i=0; i < RageTime; i += 0.1f) 
        {
            RageShoot();
            print(i);
            yield return new WaitForSeconds(0.1f);
        }
        EndRage();
        onRageEnd.Invoke();
    }
}
