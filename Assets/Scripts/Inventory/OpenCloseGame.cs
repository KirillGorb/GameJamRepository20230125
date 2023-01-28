using UnityEngine;

public class OpenCloseGame : MonoBehaviour
{
    public static bool isGameMode = true;

    [SerializeField] private GameObject _panelInventory;

    private bool isOpenInventory = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOpenInventory)
            SetCloseOpen();
        else if (Input.GetKeyDown(KeyCode.I) && isOpenInventory)
            SetCloseOpen(false);
    }

    private void SetCloseOpen(bool isSet = true)
    {
        _panelInventory.SetActive(isSet);
        Cursor.lockState = isSet ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isSet;
        isOpenInventory = isSet;
        isGameMode = !isSet;
    }
}