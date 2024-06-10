using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _initialMousePosition;
    private Vector3 _startRotation;
    private bool _isDragging = false;

    void Start()
    {
        _mainCamera = Camera.main;
        _startRotation = transform.eulerAngles;
    }

    void Update()
    {
        if (_isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 direction = currentMousePosition - _initialMousePosition;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(_startRotation.x, -angle, _startRotation.z));

            if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
                transform.rotation = Quaternion.Euler(_startRotation); // Optional: Reset to original rotation
            }
        }
    }

    void OnMouseDown()
    {
        _initialMousePosition = Input.mousePosition;
        _isDragging = true;
    }
}
