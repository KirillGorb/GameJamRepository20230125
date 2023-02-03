using UnityEngine;

public class DoorOpenPlayer : MonoBehaviour
{
    [SerializeField] private float _distancy;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _cameraPoint;

    private bool SetOpen = true;

    private void Update()
    {

        if (Physics.Raycast(transform.position, _cameraPoint.position * _distancy, out RaycastHit hit, _distancy, _layreObject) && hit.collider.TryGetComponent(out DoorOpenClose _ddor) && Input.GetKeyDown(KeyCode.E))
        {
            _ddor.OpenClose(SetOpen);
            SetOpen = !SetOpen;
        }
    }
}