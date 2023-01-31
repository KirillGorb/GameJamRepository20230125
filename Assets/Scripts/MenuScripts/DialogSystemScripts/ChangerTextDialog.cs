using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangerTextDialog : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _timer;

    [SerializeField] private DialogListString _dialogTexts;

    private int id = 0;

    private void Start()
    {
        StartCoroutine(TextChange());
    }

    private IEnumerator TextChange()
    {
        _panel.SetActive(true);
        foreach (var item in _dialogTexts.Text)
        {
            _text.text = item;
            yield return new WaitForSeconds(_timer);
        }
        _panel.SetActive(false);
    }
}
