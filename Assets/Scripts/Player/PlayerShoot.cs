using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bullet_spawn;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(bullet, 
                        bullet_spawn.transform.position, 
                         Quaternion.Euler(new Vector3(0.0f,0.0f,
                                                transform.rotation.eulerAngles.z - 90.0f)));
        }    
    }
}
