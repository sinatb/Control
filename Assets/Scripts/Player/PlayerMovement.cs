using UnityEngine;
using Unity.Mathematics;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Player _p;
    private Vector2 _dir;
    private Vector3 _mousepos;
    private Vector2 _target;
    private float _angle;
    
    [SerializeField]
    private Camera maincam;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _p = gameObject.GetComponent<Player>();
    }
    private void Update()
    {
        //getting vertical and horizontal input
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        //getting the mouse position
        _mousepos = maincam.ScreenToWorldPoint(Input.mousePosition);
        //calculating the rotation needed to face the mouse
        var deltaX = _mousepos.x - transform.position.x;
        var deltaY = _mousepos.y - transform.position.y;
        _angle = math.degrees(math.atan2(deltaY, deltaX));
        //calculating movement direction
        _dir = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        //moving the player
        _rb.MovePosition((Vector2)transform.position + _dir * (_p.Speed * Time.deltaTime));
        //rotating the player
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));
    }
}
