using UnityEngine;
using UnityEngine.UI;

public class TextRenderOnLanges : MonoBehaviour
{
    [SerializeField] private string[] _text;

    private Text _textChange;

    private void Start()
    {
        _textChange = GetComponent<Text>();
        Checnge();
    }

    public void Checnge()
    {
        _textChange.text = _text[LagasuSave.IdLagasu];
    }
}
