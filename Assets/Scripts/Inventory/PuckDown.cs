using UnityEngine;

public class PuckDown : MonoBehaviour
{
    [SerializeField] private float _distancy;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _cameraPoint;

    [SerializeField] private Inventary _inventary;

    private Vector3 direction => Camera.main.transform.TransformDirection(Vector3.forward);

    private void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, direction, out RaycastHit hit, _distancy, _layreObject) && Input.GetKeyDown(KeyCode.E))
        {
            var s = hit.collider;

            if (_inventary.PuckDown(s.GetComponent<Item>().id))
                s.GetComponent<RenderMathin>().SetNewMathin();
        }
    }
}
