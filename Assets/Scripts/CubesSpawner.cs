using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Cube _cube;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private int _number = 2;

    public void Spawn(Vector3 position, Vector3 scale)
    {
        for (int i = 0; i < GetCubesCount(); i++)
        {
            var cloneCube = Instantiate(_cube, position, transform.rotation);
            cloneCube.transform.localScale = scale / _number;
            _colorChanger.SetMaterial(cloneCube.GetComponent<Renderer>());
        }
    }

    private int GetCubesCount()
    {
        int cubesCount = UnityEngine.Random.Range(_minCubesCount, _maxCubesCount);

        return cubesCount;
    }
}
