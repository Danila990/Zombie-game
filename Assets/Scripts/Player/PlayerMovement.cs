using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed = 5;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _joystick = _joystick.GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        _movement = new Vector2(_joystick.Horizontal, _joystick.Vertical) * _moveSpeed;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement;
    }
}