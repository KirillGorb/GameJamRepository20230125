﻿using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu()]
public class SaveHallway : ScriptableObject
{
    [SerializeField] private TypeSpawnDoor _typeSpawnDoor = TypeSpawnDoor.NewHallway;

    [SerializeField] private List<DoorSave> _rooms;
    [SerializeField] private List<bool> _isOpenDoor;

    public bool this[int id] => _isOpenDoor[id];

    public TypeSpawnDoor TypeSpawnDoor { get => _typeSpawnDoor; set => _typeSpawnDoor = value; }

    public void ResetList()
    {
        _rooms.Clear();
        _isOpenDoor.Clear();
    }

    public List<DoorSave> RenderListData() => _rooms;

    public void AddDoor(DoorSave door)
    {
        _rooms.Add(door);
        _isOpenDoor.Add(false);
    }
    public void SetIsOpenDoor(int id) => _isOpenDoor[id] = true;
}