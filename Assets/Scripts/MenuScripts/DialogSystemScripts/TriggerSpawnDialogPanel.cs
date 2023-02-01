using UnityEngine;

public class TriggerSpawnDialogPanel : MonoBehaviour
{
    [SerializeField] private DialogListString _dialogTexts;
    [SerializeField] private ChangerTextDialog _change;
    [SerializeField] private Transform _canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var s = Instantiate(_change, _canvas);
            s.SetDialog(_dialogTexts);
            Destroy(gameObject);
        }
    }
}