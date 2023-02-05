using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PuckDown : MonoBehaviour
{
    [SerializeField] private Animation[] _animPanel;

    [SerializeField] private int idScene;

    [SerializeField] private float _timer;
    [SerializeField] private float _distancy;

    [SerializeField] private LayerMask _layreObject;

    [SerializeField] private Transform _cameraPoint;

    [SerializeField] private Inventary _inventary;

    private Vector3 direction => Camera.main.transform.TransformDirection(Vector3.forward);

    private void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, direction, out RaycastHit hit, _distancy, _layreObject) && Input.GetKeyDown(KeyCode.E))
        {
            var s = hit.collider;

            if (_inventary.PuckDown(s.GetComponent<Item>().id))
            {
                s.GetComponent<RenderMathin>().SetNewMathin();
                StartCoroutine(SceneRender());
            }
        }
    }

    public IEnumerator SceneRender()
    {
        yield return new WaitForSeconds(_timer / 4);
        OpenCloseGame.isGameMode = false;

        foreach (var item in _animPanel)
        {
            item.gameObject.SetActive(true);
            item.Play();
            yield return new WaitForSeconds(_timer);
        }

        yield return new WaitForSeconds(_timer);

        SceneManager.LoadScene(idScene);
        OpenCloseGame.isGameMode = true;
    }
}
