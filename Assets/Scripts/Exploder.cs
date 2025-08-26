using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Vector3 position, Vector3 scale = default, List<Rigidbody> cubesToExplode = default)
    {
        float forceUp = 0;
        float radiusUp = 0;
        int coefficientNumber = 3;

        if (scale != default)
        {
            forceUp = (_explosionForce / scale.x) * coefficientNumber;
            radiusUp = (_explosionRadius / scale.x) * coefficientNumber;

            Instantiate(_effect, position, transform.rotation);
            SimulateExplosion(GetExplodableObjects(position), position, _explosionForce + forceUp, _explosionRadius + radiusUp);
        }
        else
        {
            SimulateExplosion(cubesToExplode, position, _explosionForce, _explosionRadius);

            foreach (Rigidbody cubeToExplode in cubesToExplode)
            {
                Debug.Log(cubeToExplode);
            }
        }

        Debug.Log($"Радиус {_explosionRadius + radiusUp}");
        Debug.Log($"Сила {_explosionForce + forceUp}");
    }

    private void SimulateExplosion(List<Rigidbody> cubes, Vector3 position, float forceValue, float radiusValue)
    {
        foreach (Rigidbody explodableObject in cubes)
        {
            if (explodableObject != null)
            explodableObject.AddExplosionForce(forceValue, position, radiusValue);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, _explosionRadius);

        List<Rigidbody> explosion = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                explosion.Add(hit.attachedRigidbody);

        return explosion;
    }
}
