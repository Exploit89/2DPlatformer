using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private AudioSource _sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _reached?.Invoke();
            _sound.Play();
            var sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _reached?.Invoke();
        Destroy(gameObject);
    }
}
