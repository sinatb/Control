using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float shoot_timer;
    [SerializeField] private float timer;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float ShootTimer
    {
        get => shoot_timer;
        set => shoot_timer = value;
    }
    public void ReceiveDamage(float ammount)
    {
        if (timer > 0)
            timer -= ammount;
    }

}
