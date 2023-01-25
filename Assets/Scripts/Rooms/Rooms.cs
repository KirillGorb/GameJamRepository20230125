using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Rooms : ScriptableObject
{
    [SerializeField] private List<RoomData> _rooms;

    public RoomData this[TypeRoom id] => _rooms[(int)id];
}

[System.Serializable]
public struct RoomData
{
    public TypeRoom _typeRoom;
    public Transform[] _prefabRoom;
}

public enum TypeRoom
{
    Right = 0,
    Left = 1,
    Top = 2,
    Button = 3,
    HallwayTop = 4,
    HallwayButton = 5
}