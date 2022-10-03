using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private bool _isDirectionRight = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
            transform.Translate(0, _speed * Time.deltaTime, 0);
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
