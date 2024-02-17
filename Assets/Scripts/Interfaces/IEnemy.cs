public interface IEnemy
{
    public float Damage
    {
        get;
        set;
    }
    public void Attack(Player p);
    public void ReceiveDamage(float amount);
    public void Die(bool drop);
}
