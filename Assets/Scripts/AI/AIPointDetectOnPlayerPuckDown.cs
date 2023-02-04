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
        if (Vector3.Distance(transform.position, point) <= _distancyDetectNewPoint)
        {
            Debug.Log(111);
            _moveAI.AddDestinationInterrupt(DestinationPoint.AddNew(point));
        }
    }
}