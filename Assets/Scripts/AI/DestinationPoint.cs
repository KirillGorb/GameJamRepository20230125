using UnityEngine;
using System.Threading.Tasks;

public class DestinationPoint : MonoBehaviour
{
    [SerializeField] private int _animationCode;

    [SerializeField] private float _actionDurationMin;
    [SerializeField] private float _actionDurationMax;
    [SerializeField] private float _StoppingDist;
    [SerializeField] float _DelayStart;

    [SerializeField] private bool _repeat;
    [SerializeField] UnityEngine.Events.UnityEvent onEnter;
    [SerializeField] UnityEngine.Events.UnityEvent onExit;
    [SerializeField] UnityEngine.Events.UnityEvent<float> onOnProcess;

    public int animationCode => _animationCode;
    public float actionDuration => Random.Range(_actionDurationMin, _actionDurationMax);

    public float stopDist => _StoppingDist;
    public bool repeat => _repeat;
    
    public static DestinationPoint AddNew(Vector3 position, Quaternion rotation = default, float duration = 1, int animMode = 0, float stopDist = 0.5f, float durationVariety = 0, string name = "Dest", float delay = 1)
    {
        GameObject point = new GameObject($"{name} D{duration} A{animMode}");
        point.transform.position = position;
        point.transform.rotation = rotation;
        DestinationPoint p = point.AddComponent<DestinationPoint>();
        p._animationCode = animMode;
        p._actionDurationMin = duration - durationVariety / 2;
        p._actionDurationMax = duration + durationVariety / 2;
        p._StoppingDist = stopDist;
        p._DelayStart = delay;
        return p;
    }

    public async void Enter()
    {
        await Task.Delay(Mathf.FloorToInt(_DelayStart * 1000));

        onEnter?.Invoke();
    }

    public void Exit()
    {
        onExit?.Invoke();
    }

    public void Process(float p)
    {
        onOnProcess?.Invoke(p);
    }

}