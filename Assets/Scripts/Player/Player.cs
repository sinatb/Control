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
    private void GameOver()
    {
        speed = 0;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerRage>().enabled = false;
        GetComponent<PlayerCollision>().enabled = false;
        GetComponent<PlayerShoot>().enabled = false;
        GetComponent<PlayerRage>().enabled = false;
        StopAllCoroutines();
    }
    private void Awake()
    {
        SetTimer();
        _rm = GetComponent<PlayerRage>();
        PlayerRage.onRageEnd += SetTimer;
        GameManager.gm += GameOver;
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
            _inRage = true;
            StartCoroutine(_rm.Rage());
        }
    }
}
