using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;

    [SerializeField] private float _speed;
    [SerializeField] private float lookXLimit;

    private float rotationX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        rotationX += -Input.GetAxis("Mouse Y") * _speed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        _camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        _player.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _speed, 0);
    }
}