using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private float _speedWalk;
    [SerializeField] private float _speedRun;
    [SerializeField] private float _speedSed;

    [SerializeField] private float _gravityScale;

    [SerializeField] private CharacterController _characterController;

    private bool isRun => Input.GetKey(KeyCode.LeftShift);
    private bool isSed => Input.GetKey(KeyCode.LeftControl);

    private float Speed => (isSed ? _speedSed : (isRun ? _speedRun : _speedWalk)) * Time.deltaTime;
    private float MoveOY => _characterController.isGrounded ? 0 : -_gravityScale * Time.deltaTime;

    private float MoveInputHor => Input.GetAxis("Horizontal") * Speed;
    private float MoveInputVer => Input.GetAxis("Vertical") * Speed;

    private Vector3 forward => transform.TransformDirection(Vector3.forward);
    private Vector3 right => transform.TransformDirection(Vector3.right);

    private Vector3 MoveVector => forward * MoveInputVer + Vector3.up * MoveOY + right * MoveInputHor;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!OpenCloseGame.isGameMode) return;
        SedMode();
        _characterController.Move(MoveVector);
    }

    private void SedMode()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _characterController.height = 1;
            _characterController.center = new Vector3(0, 0.5f, 0);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            _characterController.height = 2;
            _characterController.center = new Vector3(0, 0, 0);
            _characterController.Move(new Vector3(0, 1, 0));
        }
    }
}