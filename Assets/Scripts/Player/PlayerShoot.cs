using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Player))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletSpawn;
    private float _shootTimer;
    private bool _canshoot;
    private Player _p;

    private IEnumerator delay_shoot()
    {
        if (!_canshoot)
        {
            yield return new WaitForSeconds(_shootTimer);
            _canshoot = true;
        }

    }

    private void Start()
    {
        _p = gameObject.GetComponent<Player>();
        _shootTimer = _p.ShootTimer;
        _canshoot = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (_canshoot)
            {
                Instantiate(bullet,
                    bulletSpawn.transform.position,
                    Quaternion.Euler(new Vector3(0.0f, 0.0f,
                        transform.rotation.eulerAngles.z - 90.0f)));
                _canshoot = false;
                StartCoroutine(delay_shoot());
            }
        }    
    }
}
