using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventary : MonoBehaviour
{
    [SerializeField] private List<Sprite> _itemsIkone;
    [SerializeField] private List<GameObject> _items;

    [SerializeField] private List<OnCell> _ikoneRender;

    private GameObject _item;

    public void PuckUp(GameObject item, int id)
    {
        bool isSet = false;

        if (id < _itemsIkone.Count)
        {
            for (int i = 0; i < _ikoneRender.Count; i++)
            {
                if (_ikoneRender[i].isFull) continue;

                isSet = true;
                _ikoneRender[i].isFull = true;
                _ikoneRender[i]._image.sprite = _itemsIkone[id];

                break;
            }
        }
        if (isSet)
        {
            Destroy(item);
            _item = _items[id];
        }

        Debug.Log(id);
    }
}

[System.Serializable]
class OnCell
{
    public bool isFull;
    public Image _image;
}