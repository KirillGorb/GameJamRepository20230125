using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangerTextDialog : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _timer;

    public void SetDialog(DialogListString dialogTexts, int id) =>
        StartCoroutine(TextChange(dialogTexts, id));

    private IEnumerator TextChange(DialogListString dialogTexts, int id)
    {
        foreach (var item in dialogTexts.Text(id))
        {
            _text.text = item;
            yield return new WaitForSeconds(_timer);
        }
        Destroy(_panel.gameObject);
    }
}