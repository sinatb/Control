using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
[RequireComponent(typeof(PlayerShoot),typeof(PlayerBoost),typeof(Player))]
public class PlayerRage : MonoBehaviour
{
    [SerializeField] private float RageTime;
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Camera maincam;
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
    private Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
    private void RageShoot()
    {
        var position = transform.position;
        var mousepos = maincam.ScreenToWorldPoint(Input.mousePosition);
        var deltaX = mousepos.x - transform.position.x;
        var deltaY = mousepos.y - transform.position.y;
        var angle_mouse = math.degrees(math.atan2(deltaY, deltaX));
        foreach (var x in ShootingPos)
        {
            var nx = rotate(x, angle_mouse * Mathf.Deg2Rad);
            var angle = Mathf.Atan2(nx.x, nx.y) * Mathf.Rad2Deg;
            Instantiate(Bullet,
                (Vector2)position + nx,
                Quaternion.Euler(new Vector3(0.0f, 0.0f, -angle))
                );
        }
    }
    public void EndRage() 
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
