using UnityEngine;
using System;

public class PuckUpItem : MonoBehaviour
{
    [SerializeField] private float _distancy;
    [SerializeField] private LayerMask _layreObject;
    [SerializeField] private Transform _cameraPoint;

    //[SerializeField] private OnPuckUpChencger _changePuckUp;
    //[SerializeField] private ButtonChange _changeButton;
    [SerializeField] private Inventary _inventary;

    private void Update()
    {
        if (!OpenCloseGame.isGameMode) return;
        //S();
        OnPuckUp();
    }

    //private void S()
    //{
    //    UIDetectButton uiText;
    //    bool isDetect;
    //    GameObject s;
    //    (isDetect, s, uiText) = _changePuckUp.IsDetect<UIDetectButton>(transform, true);
    //    if (isDetect)
    //    {
    //        _changeButton.ChangeButtonText(true, uiText);
    //        PuckUp(s.GetComponent<Item>());
    //    }
    //    else
    //        _changeButton.ChangeButtonText(false);
    //}

    //private void PuckUp(Item item) =>
    //    _inventary.PuckUp(item.gameObject, item.id);

    private Vector3 direction => Camera.main.transform.TransformDirection(Vector3.forward);

    private void OnPuckUp()
    {
        if (Physics.Raycast(Camera.main.transform.position, direction, out RaycastHit hit, _distancy, _layreObject) && Input.GetKeyDown(KeyCode.E))
        {
            var item = hit.collider.gameObject.GetComponent<Item>();
            _inventary.PuckUp(item.gameObject, item.id);
        }
    }
}

//[Serializable]
//public class OnPuckUpChencger
//{
//    public static event Action Change;

//    [SerializeField] private ChangeObject _changeObject;
//    [SerializeField] private LayerMask _layreObject;

//    public (bool, GameObject, T) IsDetect<T>(Transform transform, bool buttonCklic)
//    {
//        T ss = default(T);
//        var s = Physics.Raycast(transform.position, _changeObject._cameraPoint.position * _changeObject._distancy, out RaycastHit hit, _changeObject._distancy, _layreObject) && buttonCklic && hit.collider.TryGetComponent<T>(out ss);
//        return (s, hit.collider.gameObject, ss);
//    }
//}

//[Serializable]
//public struct ChangeObject
//{
//    public Transform _cameraPoint;
//    public float _distancy;
//}