using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

}
