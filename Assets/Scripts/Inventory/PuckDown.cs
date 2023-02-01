using UnityEngine;

public class PuckDown : MonoBehaviour
{
    [SerializeField] private float _distancy;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _cameraPoint;

    [SerializeField] private Inventary _inventary;

    private void Update()
    {
        if (Physics.Raycast(transform.position, _cameraPoint.position * _distancy, out RaycastHit hit, _distancy, _layreObject) && Input.GetKeyDown(KeyCode.E))
        {
            var s = hit.collider;

            _inventary.PuckDown(s.GetComponent<Item>().id);
            s.GetComponent<RenderMathin>().SetNewMathin();
        }
    }
}
