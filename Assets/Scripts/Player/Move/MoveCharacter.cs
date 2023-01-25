using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private MoveData[] _moveData;

    private IMove _move = new IMove();

    [SerializeField] private CharacterController _characterController;

    private OnMoveMove _moveMode = OnMoveMove.Run;

    private Vector3 forward => transform.TransformDirection(Vector3.forward);
    private Vector3 right => transform.TransformDirection(Vector3.right);
    private Vector3 MoveVector => (forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal")) * _move.Moveble() * Time.deltaTime;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        SwichMoveMode(OnMoveMove.Walk);
    }

    private void Update()
    {
        SetMoveMode();
        _characterController.Move(MoveVector);
    }

    private void SetMoveMode()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            SwichMoveMode(OnMoveMove.Run);
        else if (Input.GetKey(KeyCode.Space))
            SwichMoveMode(OnMoveMove.Somersault);
        else
            SwichMoveMode(OnMoveMove.Walk);
    }

    private void SwichMoveMode(OnMoveMove moveMode)
    {
        if (_moveMode == moveMode) return;

        _moveMode = moveMode;
        _move.SetMove(_moveData[(int)_moveMode]);

        Debug.Log(_moveData[(int)_moveMode].Speed);
    }
}

public class IMove
{
    private MoveData _move;

    public void SetMove(MoveData move)
    {
        _move = move;
    }

    public virtual float Moveble()
    {
        return _move.Speed;
    }

    public virtual void MovingCosts(ref float endurance)
    {
        endurance -= _move.Cost;
    }
}

[Serializable]
public struct MoveData
{
    [SerializeField] private OnMoveMove MoveMode;

    public float Speed;
    public float Recharge;

    public float Cost;
}

public enum OnMoveMove
{
    Walk = 0,
    Run = 1,
    Somersault = 2
}