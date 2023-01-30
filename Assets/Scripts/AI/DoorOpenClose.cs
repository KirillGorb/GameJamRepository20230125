using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    [SerializeField] private GameObject _oneState;
    [SerializeField] private GameObject _twoState;

    private void Start()
    {
        OpenClose();
    }

    public void OpenClose(bool isOpen = false)
    {
        _oneState.SetActive(!isOpen);
        _twoState.SetActive(isOpen);
    }
}
