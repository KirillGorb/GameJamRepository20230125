using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TextRenderOnLanges[] _renders;
    [SerializeField] private GameObject[] _panels;

    [SerializeField] private int _idScene = 1;

    [SerializeField] private LagasuSave _saveLages;


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
        _saveLages.IdLagasu = id;
        RenderTextLanges();
    }


    private void RenderTextLanges()
    {
        foreach (var item in _renders)
        {
            item.RenderText(_saveLages.IdLagasu);
        }
    }

    private IEnumerator StartScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(_idScene);
    }
}