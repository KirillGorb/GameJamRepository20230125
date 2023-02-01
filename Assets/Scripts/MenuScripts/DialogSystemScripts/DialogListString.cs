using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DialogListString : ScriptableObject
{
    [SerializeField] private List<string> _text;

    public string this[int id] => _text[id];
    public List<string> Text => _text;
}