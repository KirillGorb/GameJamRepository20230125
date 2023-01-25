using UnityEngine;

public class GenerateTypeDoors : MonoBehaviour
{
    private static LoadSceneOnTrigger[] _doors;

    public static void SetDoors()
    {
        _doors = FindObjectsOfType<LoadSceneOnTrigger>();

        int idHallway = Random.Range(0, _doors.Length);
        _doors[idHallway].SetTypeRenderScene(TypeScene.Hallway);

        for (int i = 0; i < _doors.Length && i != idHallway; i++)
        {
            _doors[i].SetTypeRenderScene(TypeScene.Room);
        }
    }
}