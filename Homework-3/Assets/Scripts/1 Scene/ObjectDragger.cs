using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    [SerializeField] private Transform _objectTransform;
    [SerializeField] private bool _isDragging;
    [SerializeField] private RaycastHandler _raycastHandler;

    private Plane plane = new Plane(Vector3.up, 0);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isDragging == false)
        {
            DragObject(_raycastHandler.GetObjectFromRaycast());
        }
        else if (Input.GetMouseButtonDown(0) && _isDragging == true)
        {
            _isDragging = false;
        }
        else if (_isDragging == true)
        {
            SetPositionObject();
        }
    }

    private void DragObject(Transform transform)
    {
        if (transform == null)
            return;

        _objectTransform = transform;
        _isDragging = true;
    }

    private void SetPositionObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;

        // Определяем, где луч пересекает плоскость
        if (plane.Raycast(_raycastHandler.GetRayFromMouse(), out distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);  // Точка пересечения с плоскостью
            _objectTransform.position = hitPoint;  // Перемещаем объект в эту точку
        }
    }

    private Ray GetRayFromMouse() => Camera.main.ScreenPointToRay(Input.mousePosition); // вынести в общий класс
}
