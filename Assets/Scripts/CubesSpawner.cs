using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Cube _cube;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;
    private int _cubeReductionValue = 2;

    private List<Rigidbody> _cubesRigidbody = new List<Rigidbody>();

    public void Spawn(Cube cube, Vector3 position, Vector3 scale)
    {
        for (int i = 0; i < GetCubesCount(); i++)
        {
            var cloneCube = Instantiate(_cube, position, transform.rotation);
            cloneCube.ChangeChanceSplitValue(cube.GetChanceSplitValue);
            cloneCube.transform.localScale = scale / _cubeReductionValue;
            _colorChanger.SetMaterial(cloneCube.GetComponent<Renderer>());

            _cubesRigidbody.Add(cloneCube.GetComponent<Rigidbody>());
            Debug.Log(cube.GetChanceSplitValue);
        }

        Destroy(cube.transform.gameObject);
    }

    public List<Rigidbody> GetCubesToExplode()
    {
        return new List<Rigidbody>(_cubesRigidbody);
    }

    private int GetCubesCount()
    {
        int cubesCount = UnityEngine.Random.Range(_minCubesCount, _maxCubesCount);

        return cubesCount;
    }
}
