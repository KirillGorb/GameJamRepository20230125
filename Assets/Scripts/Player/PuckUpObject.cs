using UnityEngine;

public class PuckUpObject : MonoBehaviour
{
    [SerializeField] private float _distancy;
    [SerializeField] private float _speedMoveObject;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _objectInPointState;
    [SerializeField] private Transform _objectInPointMove;
    [SerializeField] private Transform _cameraPoint;

    private bool isPuckUp = false;
    private bool isObjectMove;

    private GameObject _object;

    private void Update()
    {
        PuckUp();
        Mouse();
    }

    private void PuckUp()
    {
        if (Physics.Raycast(transform.position, _cameraPoint.position * _distancy, out RaycastHit hit, _distancy, _layreObject) && Input.GetMouseButtonUp(0) && !isPuckUp)
        {
            _object = hit.collider.gameObject;
            Debug.Log(_object);
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
            if (isObjectMove)
            {
                _object.transform.position = _objectInPointMove.position;
            }
            else
            {
                _object.transform.position = _objectInPointState.position;
                _object.transform.rotation = transform.rotation;
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                _objectInPointMove.transform.position += Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * _speedMoveObject;
            }

            if (Input.GetMouseButton(1))
            {
                CameraMove.isMoveCamera = false;
                isObjectMove = true;

                _object.transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse X") * _speedMoveObject, -Input.GetAxis("Mouse Y") * _speedMoveObject, 0);
            }

            if (Input.GetMouseButtonUp(1))
            {
                CameraMove.isMoveCamera = true;
                isObjectMove = false;

                _object.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
