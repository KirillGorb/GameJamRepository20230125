using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    [SerializeField] int _animationCode;
    [SerializeField] float _actionDurationMin;
    [SerializeField] float _actionDurationMax;
    [SerializeField] float _StoppingDist;
    [SerializeField] bool _repeat;


    public static DestinationPoint AddNew(Vector3 position, Quaternion rotation = default, float duration = 1, int animMode = 0, float stopDist = 0.5f, float durationVariety = 0, string name = "Dest")
    {
        GameObject point = new GameObject($"{name} D{duration} A{animMode}");
        point.transform.position = position;
        point.transform.rotation = rotation;
        DestinationPoint p = point.AddComponent<DestinationPoint>();
        p._animationCode = animMode;
        p._actionDurationMin = duration - durationVariety / 2;
        p._actionDurationMax = duration + durationVariety / 2;
        p._StoppingDist = stopDist;
        return p;
    }

    public int animationCode => _animationCode;
    public float actionDuration => Random.Range(_actionDurationMin, _actionDurationMax);
    
    public float stopDist => _StoppingDist;
    public bool repeat => _repeat;


}
