using UnityEngine;

public class FieldOfViewCondition
{
    private Transform _sourceObject;
    private float _fieldOfViewDegree;

    public FieldOfViewCondition(Transform sourceObject, float fieldOfViewDegree)
    {
        _sourceObject = sourceObject;
        _fieldOfViewDegree = fieldOfViewDegree;
    }

    public bool IsCompleteFor(Transform target)
    {
        Vector3 directionToTarget = target.position - _sourceObject.position;

        Vector2 convertedDirectionToTarget = new Vector2(directionToTarget.x, directionToTarget.z);
        Vector2 convertedObjectForward = new Vector2(_sourceObject.forward.x, _sourceObject.forward.z);

        float dotProduct = Vector2.Dot(convertedDirectionToTarget, convertedObjectForward); // —кал€рное произведение

        float degreeToTarget = Mathf.Acos(dotProduct / (convertedDirectionToTarget.magnitude * convertedObjectForward.magnitude)) * Mathf.Rad2Deg;

        if (degreeToTarget > _fieldOfViewDegree / 2)
            return false;

        return true;
    }
}
