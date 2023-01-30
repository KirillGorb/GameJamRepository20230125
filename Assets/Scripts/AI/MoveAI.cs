using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{
    [SerializeField] private GameObject _startMovePoint;
    [SerializeField] private GameObject _movePoint;

    [SerializeField] private float _timeStop;
    [SerializeField] private float _minDistancy;

    private bool _isMove = true;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Move(); 
        DetectPoint();
    }

    private void Move()
    {
        _agent.destination = (_isMove ? _movePoint : _startMovePoint).transform.position;
    }

    private void DetectPoint()
    {
        if (Vector3.Distance(_agent.transform.position, _movePoint.transform.position) <= _minDistancy && _isMove)
        {
            StartCoroutine(Stoping());
        }
    }

    private IEnumerator Stoping()
    {
        yield return new WaitForSeconds(_timeStop);
        _isMove = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DoorOpenClose doorOpenClose))
            doorOpenClose.OpenClose(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DoorOpenClose doorOpenClose))
            doorOpenClose.OpenClose(false);
    }
}
