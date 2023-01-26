using UnityEngine;

public class SpawnRooms : MonoBehaviour
{
    [SerializeField] private Rooms _rooms;
    [SerializeField] private SaveHallway _saveHallway;

    [SerializeField] private DoorSpawnData[] _spawnData;

    private Vector3 SpawmPoint(int id) =>
        new Vector3(Random.Range(_spawnData[id]._startPoint.position.x,
        _spawnData[id]._endPoint.position.x), _spawnData[id]._startPoint.position.y,
        Random.Range(_spawnData[id]._startPoint.position.z, _spawnData[id]._endPoint.position.z));

    private void Start()
    {
        SetSceneData();

        GenerateTypeDoors.SetDoors();
    }

    private void SetSceneData()
    {
        switch (_saveHallway.TypeSpawnDoor)
        {
            case TypeSpawnDoor.NewHallway:
                _saveHallway.ResetList();
                CreateAndSave();
                break;
            case TypeSpawnDoor.OverideHallway:
                RespawnHallway();
                break;
        }
    }

    private void CreateAndSave()
    {
        for (int i = 0; i < _spawnData.Length; i++)
        {
            var room = _rooms[_spawnData[i]._roomType]._prefabRoom;
            for (int j = 0; j < _spawnData[j].countRoom; j++)
            {
                var obj = Instantiate(room[Random.Range(0, room.Length)], SpawmPoint(i), Quaternion.identity);
                _saveHallway.AddDoor(new DoorSave(obj.position, _spawnData[i]._roomType));
            }
        }
    }

    private void RespawnHallway()
    {
        var list = _saveHallway.RenderListData();

        for (int i = 0; i < list.Count; i++)
        {
            var room = _rooms[list[i].RoomType]._prefabRoom;
            Instantiate(room[Random.Range(0, room.Length)], list[i].RoomPos, Quaternion.identity);
        }
    }
}

[System.Serializable]
public struct DoorSave
{
    public Vector3 RoomPos;
    public TypeRoom RoomType;

    public DoorSave(Vector3 roomPos, TypeRoom roomType)
    {
        RoomPos = roomPos;
        RoomType = roomType;
    }

}

[System.Serializable]
public struct DoorSpawnData
{
    public Transform _startPoint;
    public Transform _endPoint;

    public int countRoom;

    public TypeRoom _roomType;
}

public enum TypeSpawnDoor
{
    NewHallway,
    OverideHallway
}