using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextRenderOnLanges : MonoBehaviour
{
    [SerializeField] private string[] _textRender = new string[3];

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
        RenderText(0);
    }

    public void RenderText(int id)
    {
        _text.text = _textRender[id < _textRender.Length && id >= 0 ? id : 0];
        Debug.Log(id);
    }
}