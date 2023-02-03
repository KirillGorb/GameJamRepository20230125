using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventary : MonoBehaviour
{
    [SerializeField] private Sprite _defalteSpriteInventory;

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
                _ikoneRender[i].idItem = id;
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

    public bool PuckDown(int id)
    {
        bool isPuck = false;

        foreach (var item in _ikoneRender)
        {
            if (id == item.idItem)
            {
                item.isFull = false;
                item._image.sprite = _defalteSpriteInventory;
                isPuck = true;
                break;
            }
        }

        return isPuck;
    }
}

[System.Serializable]
class OnCell
{
    public bool isFull;
    public Image _image;
    public int idItem;
}