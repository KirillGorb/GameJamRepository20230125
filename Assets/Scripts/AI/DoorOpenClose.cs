using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    [SerializeField] private Animation _anim;

    [SerializeField] private AnimationClip _openAnimClip;
    [SerializeField] private AnimationClip _closeAnimClip;

    private bool isOpen = true;

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
