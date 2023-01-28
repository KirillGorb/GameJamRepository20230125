using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void SetScene(int id) => SceneManager.LoadScene(id);
    public void Exit() => Application.Quit();
}
