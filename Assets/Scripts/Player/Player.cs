using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotatespeed;
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float RotateSpeed
    {
        get => _rotatespeed;
    }
    
}
