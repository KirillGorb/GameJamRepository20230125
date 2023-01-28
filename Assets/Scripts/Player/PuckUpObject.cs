using UnityEngine;

public class PuckUpObject : MonoBehaviour
{
    [SerializeField] private float _distancy;
    [SerializeField] private float _speedMoveObject;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _objectInPoint;
    [SerializeField] private Transform _cameraPoint;

    private bool isPuckUp = false;

    private GameObject _object;

    private void Update()
    {
        PuckUp();
        Mouse();
    }

    private void PuckUp()
    {
        if (Physics.Raycast(transform.position, _cameraPoint.position * _distancy, out RaycastHit hit, _distancy, _layreObject)&& Input.GetMouseButtonUp(0) && !isPuckUp)
        {
            _object = hit.collider.gameObject;
            Debug.Log(_object);
            CameraMove.isMoveCamera = false;
            isPuckUp = true;
        }
    }

    private void Mouse()
    {
        if (Input.GetMouseButtonDown(0) && isPuckUp)
        {
            isPuckUp = false;
            CameraMove.isMoveCamera = true;
        }

        if (isPuckUp)
        {
            _object.transform.position = _objectInPoint.position;

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                _objectInPoint.transform.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * _speedMoveObject;
            }

            if (Input.GetMouseButton(1))
            {
                _object.transform.rotation *= Quaternion.Euler( Input.GetAxis("Mouse X") * _speedMoveObject, -Input.GetAxis("Mouse Y") * _speedMoveObject, 0);
            }
        }
    }
}
