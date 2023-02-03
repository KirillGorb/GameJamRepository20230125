using UnityEngine;

public class DoorOpenPlayer : MonoBehaviour
{
    [SerializeField] private float _distancy;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _cameraPoint;

    private bool SetOpen = true;

    private Vector3 direction => Camera.main.transform.TransformDirection(Vector3.forward);

    private void Update()
    {

        if (Physics.Raycast(Camera.main.transform.position, direction, out RaycastHit hit, _distancy, _layreObject) && hit.collider.TryGetComponent(out DoorOpenClose _ddor) && Input.GetKeyDown(KeyCode.E))
        {
            _ddor.OpenClose(SetOpen);
            SetOpen = !SetOpen;
        }
    }
}