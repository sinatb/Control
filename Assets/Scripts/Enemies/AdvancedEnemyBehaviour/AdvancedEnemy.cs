using UnityEngine;

public class AdvancedEnemy : MonoBehaviour,INCUnit,IEnemy
{
    public float Speed { get; set; }
    public float Health { get; set; }
    public Vector2 Direction { get; set; }
    public float Damage { get; set; }

    public void PlanMove()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Attack(Player p)
    {
        throw new System.NotImplementedException();
    }

    public void ReceiveDamage(float amount)
    {
        throw new System.NotImplementedException();
    }
}
