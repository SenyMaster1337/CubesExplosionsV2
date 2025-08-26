using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private RayReader _rayReader;
    [SerializeField] private CubesSpawner _cubesSpawner;
    [SerializeField] private Exploder _exploder;

    private float _minPercentageValue = 0.0f;
    private float _maxPercentageValue = 100.0f;

    private void OnEnable()
    {
        _rayReader.CubeClicked += Handle;
    }

    private void OnDisable()
    {
        _rayReader.CubeClicked -= Handle;
    }

    private void Handle(Cube cube, Vector3 position, Vector3 scale)
    {
        Debug.Log(cube.GetChanceSplitValue);

        if (IsPossibleSplitCube(cube.GetChanceSplitValue))
        {
            _cubesSpawner.Spawn(cube, position, scale);
            _exploder.Explode(position, default, _cubesSpawner.GetCubesToExplode());
        }
        else
        {
            _exploder.Explode(position, scale);
        }
    }

    private bool IsPossibleSplitCube(float chanceValue)
    {
        Debug.Log(chanceValue);
        return chanceValue >= UnityEngine.Random.Range(_minPercentageValue, _maxPercentageValue);
    }
}