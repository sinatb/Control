using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float shootTimer;
    [SerializeField] private float timer;
    [SerializeField] private float MaxTime;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    private void Awake()
    {
        timer = MaxTime;
    }
    public void Consume(Dropable d)
    {
        if (timer + d.AddTime < MaxTime)
            timer += d.AddTime;
        else
            timer = MaxTime;
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
    private void Update()
    {
        timer -= Time.deltaTime/2;
    }
}
