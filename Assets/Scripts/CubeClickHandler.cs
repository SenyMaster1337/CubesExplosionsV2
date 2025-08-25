using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private RayReader _rayReader;
    [SerializeField] private CubesSpawner _cubesSpawner;
    [SerializeField] private Exploder _exploder;

    private int _minPercentageValue = 50;
    private int _maxPercentageValue = 100;
    private int _number = 2;

    private void OnEnable()
    {
        _rayReader.CubeClicked += Handle;
    }

    private void OnDisable()
    {
        _rayReader.CubeClicked -= Handle;
    }

    private void Handle(Vector3 position, Vector3 scale)
    {
        if (GetBooleanValue(UnityEngine.Random.Range(0, _maxPercentageValue)))
        {
            _cubesSpawner.Spawn(position, scale);
            _exploder.Explode(position);

            _minPercentageValue /= _number;
            _maxPercentageValue /= _number;
        }
        else
        {
            _exploder.Explode(position, scale);
        }
    }

    private bool GetBooleanValue(int percentageValue)
    {
        return percentageValue > _minPercentageValue;
    }
}
