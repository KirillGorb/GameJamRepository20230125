using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangerTextDialog : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _timer;

    public void SetDialog(DialogListString dialogTexts) =>
        StartCoroutine(TextChange(dialogTexts));

    private IEnumerator TextChange(DialogListString dialogTexts)
    {
        foreach (var item in dialogTexts.Text)
        {
            _text.text = item;
            yield return new WaitForSeconds(_timer);
        }
        Destroy(_panel.gameObject);
    }
}