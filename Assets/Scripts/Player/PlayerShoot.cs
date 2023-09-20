using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Player))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bullet_spawn;
    private float shoot_timer;
    private bool canshoot;
    private Player _p;

    private IEnumerator delay_shoot()
    {
        if (!canshoot)
        {
            yield return new WaitForSeconds(shoot_timer);
            canshoot = true;
        }

    }

    private void Start()
    {
        _p = gameObject.GetComponent<Player>();
        shoot_timer = _p.ShootTimer;
        canshoot = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canshoot)
            {
                Instantiate(bullet,
                    bullet_spawn.transform.position,
                    Quaternion.Euler(new Vector3(0.0f, 0.0f,
                        transform.rotation.eulerAngles.z - 90.0f)));
                canshoot = false;
                StartCoroutine(delay_shoot());
            }
        }    
    }
}
