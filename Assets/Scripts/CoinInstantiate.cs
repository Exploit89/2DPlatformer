using UnityEngine;

public class CoinInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _instantiatePoints;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_instantiatePoints.childCount];

        for (int i = 0; i < _instantiatePoints.childCount; i++)
        {
            _points[i] = _instantiatePoints.GetChild(i);
            GameObject newObject = Instantiate(_template, _points[i]);
        }
    }
}
