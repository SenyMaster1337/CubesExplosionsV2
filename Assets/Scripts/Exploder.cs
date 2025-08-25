using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Vector3 position, Vector3 scale = default)
    {
        float forceUp = 0;
        float radiusUp = 0;
        int coefficientNumber = 3;

        if (scale != default)
        {
            forceUp = (_explosionForce / scale.x) * coefficientNumber;
            radiusUp = (_explosionRadius / scale.x) * coefficientNumber;
            Instantiate(_effect, position, transform.rotation);
        }

        foreach (Rigidbody explodableObject in GetExplodableObjects(position))
            explodableObject.AddExplosionForce(_explosionForce + forceUp, position, _explosionRadius + radiusUp);

        Debug.Log($"Радиус {_explosionRadius + radiusUp}");
        Debug.Log($"Сила {_explosionForce + forceUp}");
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
