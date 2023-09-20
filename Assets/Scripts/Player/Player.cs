using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float shootTimer;
    [SerializeField] private float timer;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float ShootTimer
    {
        get => shootTimer;
        set => shootTimer = value;
    }
    public void ReceiveDamage(float amount)
    {
        if (timer > 0)
            timer -= amount;
    }

}
