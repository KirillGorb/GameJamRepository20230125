using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour
{
    [SerializeField] private float _distancy;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _cameraPoint;
    [SerializeField] private GameObject _textImage;

    [SerializeField] private Text _textButton;

    private void Start()
    {
        _textImage.SetActive(false);
    }

    private void Update()
    {
        if (OpenCloseGame.isGameMode)
            Changer();
    }

    public void ChangeButtonText(bool isText, UIDetectButton uiDetect = null)
    {
        if (isText && uiDetect)
        {
            _textImage.SetActive(true);
            _textButton.text = uiDetect.ButtonText;
        }
        else
        {
            _textButton.text = "";
            _textImage.SetActive(false);
        }
    }

    private void Changer()
    {
        if (Physics.Raycast(transform.position, _cameraPoint.position * _distancy, out RaycastHit hit, _distancy, _layreObject) && hit.collider.TryGetComponent(out UIDetectButton uiDetect))
            ChangeButtonText(true, uiDetect);
        else
            ChangeButtonText(false);
    }
}