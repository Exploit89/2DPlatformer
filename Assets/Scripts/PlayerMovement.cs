using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _isDirectionRight = true;
    private float _verticalSpeed;

    private float _sphereRadius = 1f;
    private bool _isGrounded;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _verticalSpeed = _rigidbody.velocity.magnitude;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _verticalSpeed == 0)
        {
            _isGrounded = Physics.CheckSphere(transform.position, _sphereRadius);

            if (_isGrounded)
            {
                _animator.SetTrigger("Jump");
                transform.Translate(0, _speed * Time.deltaTime, 0);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetTrigger("MoveLeft");

            if (_isDirectionRight)
            {
                TurnDirection();
                _isDirectionRight = false;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetTrigger("MoveRight");
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            if (!_isDirectionRight)
            {
                TurnDirection();
                _isDirectionRight = true;
            }
        }
    }

    private void TurnDirection()
    {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
