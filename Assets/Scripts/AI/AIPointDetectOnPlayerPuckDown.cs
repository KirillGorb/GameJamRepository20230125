using UnityEngine;

public class AIPointDetectOnPlayerPuckDown : MonoBehaviour
{
    [SerializeField] private float _distancyDetectNewPoint;

    private MoveAI _moveAI;

    private void Start()
    {
        _moveAI = GetComponent<MoveAI>();
        PuckUpObject.AIPointCreate += Detect;
    }

    private void Detect(Vector3 point)
    {
        if (Vector3.Distance(transform.position, point) <= _distancyDetectNewPoint && Physics.Raycast(transform.position, point, out RaycastHit hit) && hit.collider == null)
        {
            _moveAI.AddDestinationInterrupt(DestinationPoint.AddNew(point, animMode: 1, stopDist: 1, name: "Suspicious", duration: 7));
        }
    }
}