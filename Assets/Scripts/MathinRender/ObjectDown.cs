using UnityEngine;

public class ObjectDown : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }
}