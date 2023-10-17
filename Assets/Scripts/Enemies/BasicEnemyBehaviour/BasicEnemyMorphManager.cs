using UnityEngine;

public class BasicEnemyMorphManager : MonoBehaviour
{
    private BasicEnemy be1;
    private BasicEnemy be2;

    public void SetBes(BasicEnemy be1, BasicEnemy be2)
    {
        this.be1 = be1;
        this.be2 = be2;
    }
    public void Die()
    {
        
        Destroy(be1.gameObject);
        Destroy(be2.gameObject);
    }

    public Vector2 GetPos()
    {
        return (be1.transform.position + be2.transform.position) / 2;
    }
}
