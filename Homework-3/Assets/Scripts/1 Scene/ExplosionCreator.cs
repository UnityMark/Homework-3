using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCreator : MonoBehaviour
{
    [SerializeField] private RaycastHandler _raycastHandler;
    [SerializeField] private float _explosiveRadius;
    [SerializeField] private float _explosiveForce;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Vector3 explosionPosition = _raycastHandler.GetHitPointFromRayCast();

        var hitObjects = _raycastHandler.GetObjectsFromRayCast(_explosiveRadius);

        // Проверяем, что объекты найдены
        if (hitObjects == null)
        {
            Debug.LogWarning("Ни одного объекта не было найдено в радиусе взрыва.");
            return;
        }

        foreach (var hitTransform in hitObjects)
        {
            Rigidbody rb = hitTransform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_explosiveForce, explosionPosition, _explosiveRadius);
            }
            else
            {
                Debug.LogWarning($"Объект {hitTransform.name} не имеет компонента Rigidbody.");
            }
        }
    }
}
