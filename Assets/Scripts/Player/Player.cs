using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float MaxSpeed;
    private float speed;
    [SerializeField] private float shootTimer;
    [SerializeField] private float timer;
    [SerializeField] private float MaxTime;
    [SerializeField] private Slider time_slider;
    private bool running=true;
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
        running = false;
    }
    private void restart()
    {
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerRage>().enabled = true;
        GetComponent<PlayerCollision>().enabled = true;
        GetComponent<PlayerShoot>().enabled = true;
        GetComponent<PlayerRage>().enabled = true;
        GetComponent<PlayerRage>().EndRage();
        speed = MaxSpeed;
        timer = MaxTime;
        running = true;
    }
    private void Awake()
    {
        SetTimer();
        _rm = GetComponent<PlayerRage>();
        PlayerRage.onRageEnd += SetTimer;
        GameManager.rs += restart;
        GameManager.gm += GameOver;
        speed = MaxSpeed;
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
        if (running)
        {
            timer -= Time.deltaTime / 2;
            if (timer <= 0 && !_inRage)
            {
                _inRage = true;
                StartCoroutine(_rm.Rage());
            }
            time_slider.value = timer / MaxTime;
        }
    }
}
