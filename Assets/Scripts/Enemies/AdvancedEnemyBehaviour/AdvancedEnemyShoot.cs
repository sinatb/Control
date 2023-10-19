using UnityEngine;

public class AdvancedEnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet; 
    public void Shoot(Vector2 target)
    {
        var deltaX =target.x - transform.position.x;
        var deltaY =target.y - transform.position.y;
        var angle = Mathf.Atan2(deltaX, deltaY) * Mathf.Rad2Deg;
        Instantiate(bullet,
            (Vector2)transform.position + (target - (Vector2)transform.position)*0.4f,
            Quaternion.Euler(new Vector3(0.0f,0.0f,-angle))
            );
    }
}
