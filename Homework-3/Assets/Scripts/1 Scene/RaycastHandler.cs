using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler: MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    public Transform GetObjectFromRaycast()
    {
        Ray ray = GetRayFromMouse();
        Collider hitInfoCollider;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
        {
            hitInfoCollider = hitInfo.collider;
            return hitInfo.transform;
        }

        return null;
    }

    public Transform[] GetObjectsFromRayCast(float radius)
    {
        Ray ray = GetRayFromMouse();
        Collider[] hitInfoColliders;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            hitInfoColliders = Physics.OverlapSphere(hitInfo.point, radius, _layerMask);

            Transform[] objectsTransform = new Transform[hitInfoColliders.Length];

            for(int i = 0; i < objectsTransform.Length; i++)
            {
                objectsTransform[i] = hitInfoColliders[i].transform;
                Debug.Log(objectsTransform[i].name);
            }

            return objectsTransform;
        }

        return null;
    }

    public Vector3 GetHitPointFromRayCast()
    {
        Ray ray = GetRayFromMouse();
        Collider hitInfoCollider;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            hitInfoCollider = hitInfo.collider;
            return hitInfo.point;
        }

        return Vector3.zero;
    }

    public Ray GetRayFromMouse() => Camera.main.ScreenPointToRay(Input.mousePosition);
}
