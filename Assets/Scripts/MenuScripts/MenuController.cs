using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static TextRenderOnLanges[] _renders;

    [SerializeField] private GameObject[] _panels;

    private void Start()
    {
        _renders = FindObjectsOfType<TextRenderOnLanges>();

        foreach (var item in _panels)
            item.SetActive(false);
    }

    public void SetScene(float timer) => StartCoroutine(StartScene(timer));
    public void Exit() => Application.Quit();
    public void OpenServer() => Application.OpenURL("http://unity3d.com/");

    public void SetLages(int id)
    {
        LagasuSave.IdLagasu = id;
        RenderTextLanges();
    }


    private void RenderTextLanges()
    {
        foreach (var item in _renders)
            item.Checnge();
    }

    private IEnumerator StartScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
    }
}