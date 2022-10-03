using UnityEngine;
using UnityEngine.Events;

public class IsGroundedTrigger : MonoBehaviour
{
    public bool IsPlayerGrounded { get; private set; }

    public UnityEvent PlayerGrounded = new UnityEvent();
    public UnityEvent PlayerUngrounded = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsPlayerGrounded = true;
            PlayerGrounded?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsPlayerGrounded = false;
            PlayerUngrounded?.Invoke();
        }
    }
}
