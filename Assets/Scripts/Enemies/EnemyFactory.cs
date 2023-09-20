using UnityEngine;
public abstract class EnemyFactory : MonoBehaviour
{ 
    public abstract IEnemy GetEnemy(Vector3 pos);
}
