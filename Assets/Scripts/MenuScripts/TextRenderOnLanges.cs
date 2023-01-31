using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextRenderOnLanges : MonoBehaviour
{
    [SerializeField] private string[] _text = new string[3];

    private Text _textChange;

    private void Start()
    {
        _textChange = GetComponent<Text>();
        Checnge();
    }

    public void Checnge() =>
        _textChange.text = _text[LagasuSave.IdLagasu];
}
