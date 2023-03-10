using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{
    [SerializeField] private List<DestinationPoint> _points;
    //List<DestinationPoint> completed;

    [SerializeField] private UnityEngine.Events.UnityEvent<int> SetAnimatorState;

    [SerializeField] UnityEngine.Events.UnityEvent onWalkStart;
    [SerializeField] UnityEngine.Events.UnityEvent onWalkEnd;

    //[SerializeField] private float _minDistancy;

    public DestinationPoint currentPoint;

    private bool _isMove = true;
    bool _isMoveTrig;
    private bool interupt;

    private NavMeshAgent _agent;

    private void Start()
    {
        //completed = new List<DestinationPoint>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_isMove != _isMoveTrig)
        {
            if (_isMove) onWalkStart?.Invoke();
            else onWalkEnd?.Invoke();

            _isMoveTrig = _isMove;
        }

        if (currentPoint != null)
            DetectPoint();
        else
            GetNextPoint();
    }

    public void AddNewDestination(DestinationPoint point)
    {
        _points.Add(point);
    }
    public void AddDestinationAfterCurrent(DestinationPoint point)
    {
        _points.Insert(0, point);
    }
    public void AddDestinationInterrupt(DestinationPoint point, bool keepCurrent = true)
    {
        if (keepCurrent) _points.Insert(0, currentPoint);
        _points.Insert(0, point);
        if (!keepCurrent) FinalizeDP(currentPoint);

        if (!_isMove)
        {
            interupt = true;
        }
        else
        {
            GetNextPoint();
        }
    }

    private void DetectPoint()
    {
        var p1 = new Vector3(_agent.transform.position.x, 0, _agent.transform.position.z);
        var p2 = new Vector3(currentPoint.transform.position.x, 0, currentPoint.transform.position.z);

        if (Vector3.Distance(p1, p2) <= currentPoint.stopDist && _isMove)
        {
            StartCoroutine(Stoping(currentPoint));
        }
    }

    private void GetNextPoint()
    {
        if (_points.Count <= 0) return;

        currentPoint = _points[0];
        _points.RemoveAt(0);
        _agent.SetDestination(currentPoint.transform.position);
    }

    private IEnumerator Stoping(DestinationPoint point)
    {
        _isMove = false;
        SetAnimatorState?.Invoke(point.animationCode);

        _agent.isStopped = true;

        float timeStarted = Time.time;
        float delay = currentPoint.actionDuration;
        point.Enter();


        yield return new WaitWhile(() => Time.time - timeStarted < delay && !interupt);
        point.Exit();
        SetAnimatorState?.Invoke(0);

        yield return new WaitForSeconds(0.5f);
        _agent.isStopped = false;

        if (!interupt) FinalizeDP(currentPoint);

        interupt = false;
        currentPoint = null;
        _isMove = true;
    }

    private void FinalizeDP(DestinationPoint p)
    {
        if (!p) return;
        if (p.repeat) AddNewDestination(p);
        else Destroy(p.gameObject);
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