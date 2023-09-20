using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float shoot_timer;
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float ShootTimer
    {
        get => shoot_timer;
        set => shoot_timer = value;
    }

}
