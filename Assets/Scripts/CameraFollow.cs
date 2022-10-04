using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float topLimit = 10.0f;
    [SerializeField] private float bottomLimit = -2.0f;
    [SerializeField] private float followSpeed = 0.7f;

    void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Lerp(newPosition.x, _target.position.x, followSpeed);
            newPosition.y = Mathf.Lerp(newPosition.y, _target.position.y, followSpeed);
            newPosition.y = Mathf.Min(newPosition.y, topLimit);
            newPosition.y = Mathf.Max(newPosition.y, bottomLimit);
            transform.position = newPosition;
        }
    }
}
