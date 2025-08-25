using System;
using UnityEngine;

public class RayReader : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;

    private RaycastHit _hit;
    private Ray _ray;

    private int _positionZ = 1;

    public event Action<Vector3, Vector3> CubeClicked;

    private void OnEnable()
    {
        _inputHandler.Clicked += CheckRay;
    }

    private void OnDisable()
    {
        _inputHandler.Clicked -= CheckRay;
    }

    private void CheckRay()
    {
        _ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _positionZ));

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.TryGetComponent(out Cube cube))
            {
                CubeClicked.Invoke(_hit.collider.transform.position, _hit.collider.transform.localScale);
                Destroy(_hit.collider.gameObject);
            }
        }
    }
}
