using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Rooms : ScriptableObject
{
    [SerializeField] private List<RoomData> _rooms;

    public RoomData this[TypeRoom id] => _rooms[(int)id];
}