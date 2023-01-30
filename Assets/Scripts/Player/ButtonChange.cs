using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour
{
    [SerializeField] private float _distancy;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _cameraPoint;
    [SerializeField] private GameObject _textImage;

    [SerializeField] private string[] _strButton;

    [SerializeField] private Text _textButton;

    private void Start()
    {
        _textImage.SetActive(false);
    }

    private void Update()
    {
        if (!OpenCloseGame.isGameMode) return;

        if (Physics.Raycast(transform.position, _cameraPoint.position * _distancy, out RaycastHit hit, _distancy, _layreObject))
        {
            _textImage.SetActive(true);
            _textButton.text = _strButton[0];
        }
        else
        {
            _textButton.text = "";
            _textImage.SetActive(false);
        }
    }
}