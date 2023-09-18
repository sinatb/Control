using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class Input : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Player _p;
    private Vector2 _dir;
    private Vector3 _mousepos;
    private Vector2 _target;
    private Vector2 _rotation;
    
    [SerializeField]
    private Camera _maincam;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _p = gameObject.GetComponent<Player>();
    }
    private void Update()
    {
        var horizontal = UnityEngine.Input.GetAxis("Horizontal");
        var vertical = UnityEngine.Input.GetAxis("Vertical");
        _mousepos = _maincam.WorldToScreenPoint(UnityEngine.Input.mousePosition);
        _mousepos.z = 0;
        _target = _mousepos - transform.position;
        _rotation = Vector3.RotateTowards(transform.position,_target,)
        _dir = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition((Vector2)transform.position + _dir * (_p.Speed * Time.deltaTime));
        _rb.MoveRotation(Vector2.Angle((_mousepos - transform.position),Vector2.right));
    }
}
