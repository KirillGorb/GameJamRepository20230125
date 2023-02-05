using UnityEngine;

public class RenderMathin : MonoBehaviour
{
    [SerializeField] private GameObject _startMathin;
    [SerializeField] private GameObject _newMathin;

    private void Awake()
    {
        SetNewMathin(false);
    }

    public void SetNewMathin(bool isNewMathin = true)
    {
        _startMathin.SetActive(!isNewMathin);
        _newMathin.SetActive(isNewMathin);
    }
}
