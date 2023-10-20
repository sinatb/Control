using UnityEngine;

public class AdvancedEnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet; 
    public void Shoot(Vector2 target)
    {
        var position = transform.position;
        var deltaX =target.x - position.x;
        var deltaY =target.y - position.y;
        var angle = Mathf.Atan2(deltaX, deltaY) * Mathf.Rad2Deg;
        var enemyAngle = (target - (Vector2)position).normalized;
        Instantiate(bullet,
            (Vector2)position + enemyAngle*0.75f ,
            Quaternion.Euler(new Vector3(0.0f,0.0f,-angle))
            );
    }
}
