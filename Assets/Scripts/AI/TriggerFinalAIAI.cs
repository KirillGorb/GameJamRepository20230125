using UnityEngine;

public class TriggerFinalAIAI : MonoBehaviour
{
    private PuckDown _puckDown;

    private void Start()
    {
        _puckDown = FindObjectOfType<PuckDown>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AIPointDetectOnPlayerPuckDown>())
        {
            Debug.Log(2345678);
            StartCoroutine(_puckDown.SceneRender());
        }
    }
}
