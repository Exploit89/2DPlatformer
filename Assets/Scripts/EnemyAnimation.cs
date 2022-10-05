using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private WaypointMovement _waypoint;

    private Animator _animator;
    private bool _isDirectionRight = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_waypoint.CurrentPoint == 0)
        {
            var enemyMoveLeftHash = Animator.StringToHash("EnemyMoveLeft");
            _animator.SetTrigger(enemyMoveLeftHash);

            if (_isDirectionRight)
            {
                TurnDirection();
                _isDirectionRight = false;
            }
        }

        if (_waypoint.CurrentPoint != 0)
        {
            var enemyMoveRightHash = Animator.StringToHash("EnemyMoveRight");
            _animator.SetTrigger(enemyMoveRightHash);

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
