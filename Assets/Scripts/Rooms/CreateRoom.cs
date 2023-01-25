using UnityEngine;

public class CreateRoom : MonoBehaviour
{
    [SerializeField] private Rooms _listRoom;

    [SerializeField] private TypeRoom _typeSpawnRoomInPoint;

    private void Start()
    {
        Instantiate(_listRoom[_typeSpawnRoomInPoint]._prefabRoom, transform);
    }
}

[System.Serializable]
public struct RoomData
{
    public TypeRoom _typeRoom;
    public Transform _prefabRoom;
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