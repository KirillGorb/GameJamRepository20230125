using UnityEngine;

[RequireComponent(typeof(Animation))]
public class DoorOpenClose : MonoBehaviour
{

    [SerializeField] private AnimationClip _openAnimClip;
    [SerializeField] private AnimationClip _closeAnimClip;

    private bool isOpen = true;
    private Animation _anim;

    private void Start()
    {
        _anim = GetComponent<Animation>();
    }

    public void OpenClose(bool isOpen)
    {
        _anim.Play("" + (isOpen ? _openAnimClip.name : _closeAnimClip.name));
    }

    public void OpenClose()
    {
        _anim.Play("" + (isOpen ? _openAnimClip.name : _closeAnimClip.name));
        isOpen = !isOpen;
    }
}
