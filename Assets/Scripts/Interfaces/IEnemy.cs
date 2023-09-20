public interface IEnemy
{
    public float Damage
    {
        get;
        set;
    }
    public void Attack(Player p);
    public void RecieveDamage(float amount);
}
