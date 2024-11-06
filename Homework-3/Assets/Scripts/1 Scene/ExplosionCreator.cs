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

        // ���������, ��� ������� �������
        if (hitObjects == null)
        {
            Debug.LogWarning("�� ������ ������� �� ���� ������� � ������� ������.");
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
                Debug.LogWarning($"������ {hitTransform.name} �� ����� ���������� Rigidbody.");
            }
        }
    }
}
