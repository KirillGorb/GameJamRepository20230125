using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private float _speed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _player.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _speed, 0);
    }
}
