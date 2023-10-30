using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float shootTimer;
    [SerializeField] private float timer;
    [SerializeField] private float MaxTime;
    private bool _inRage;
    private PlayerRage _rm;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    private void Awake()
    {
        SetTimer();
        _rm = GetComponent<PlayerRage>();
        Debug.Log(_rm);
        PlayerRage.onRageEnd += SetTimer;
    }
    public void Consume(Dropable d)
    {
        if (timer + d.AddTime < MaxTime)
            timer += d.AddTime;
        else
            SetTimer();
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
    private void SetTimer()
    {
        timer = MaxTime;
        _inRage = false;
    }
    private void Update()
    {
        timer -= Time.deltaTime/2;
        if (timer <= 0 && !_inRage)
        {
            Debug.Log("Rage invoked");
            _inRage = true;
            StartCoroutine(_rm.Rage());
        }
    }
}
