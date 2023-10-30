using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(PlayerShoot),typeof(PlayerBoost),typeof(Player))]
public class PlayerRage : MonoBehaviour
{
    [SerializeField] private float RageTime;
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject Bullet;
    private List<Vector2> ShootingPos;
    public delegate void OnRageEnd();
    public static event OnRageEnd onRageEnd;
    private void Awake()
    {
        ShootingPos = new List<Vector2>
        {
            new Vector2(1.0f,0.0f).normalized,
            new Vector2(-1.0f,0.0f).normalized,
            new Vector2(0.0f,1.0f).normalized,
            new Vector2(0.0f,-1.0f).normalized,
            new Vector2(1.0f,1.0f).normalized,
            new Vector2(1.0f,-1.0f).normalized,
            new Vector2(-1.0f,1.0f).normalized,
            new Vector2(-1.0f,-1.0f).normalized
        };
    }
    private void InitRage()
    {
        GetComponent<PlayerShoot>().enabled = false;
        GetComponent<PlayerBoost>().enabled = false;
        Gun.SetActive(false);
    }
    private void RageShoot()
    {
        var position = transform.position;
        foreach(var x in ShootingPos)
        {
            var angle = Mathf.Atan2(x.x, x.y) * Mathf.Rad2Deg;
            Instantiate(Bullet,
                (Vector2)position + x,
                Quaternion.Euler(new Vector3(0.0f, 0.0f, -angle))
                );
        }
    }
    private void EndRage() 
    {
        GetComponent<PlayerShoot>().enabled = true;
        GetComponent<PlayerBoost>().enabled = true;
        Gun.SetActive(true);
    }
    public IEnumerator Rage()
    {
        InitRage();
        for (float i=0; i < RageTime; i += 0.1f) 
        {
            RageShoot();
            yield return new WaitForSeconds(0.1f);
        }
        EndRage();
        onRageEnd.Invoke();
    }
}
