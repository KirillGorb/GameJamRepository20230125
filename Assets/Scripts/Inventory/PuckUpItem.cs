using UnityEngine;

public class PuckUpItem : MonoBehaviour
{
    [SerializeField] private float _distancy;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _cameraPoint;

    [SerializeField] private Inventary _inventary;

    private void Update()
    {
        if (!OpenCloseGame.isGameMode) return;
        OnPuckUp();
    }

    private void OnPuckUp()
    {
        if (Physics.Raycast(transform.position, _cameraPoint.position * _distancy, out RaycastHit hit, _distancy, _layreObject) && Input.GetKeyDown(KeyCode.E))
        {
            var item = hit.collider.gameObject.GetComponent<Item>();
            _inventary.PuckUp(item.gameObject, item.id);
        }
    }
}