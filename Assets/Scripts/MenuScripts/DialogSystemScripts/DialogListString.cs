using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DialogListString : ScriptableObject
{
    [SerializeField] private List<Liss> _text;

    public List<string> Text(int id)=>_text[id].Text;
}

[System.Serializable]
struct Liss
{
    public List<string> Text;
}