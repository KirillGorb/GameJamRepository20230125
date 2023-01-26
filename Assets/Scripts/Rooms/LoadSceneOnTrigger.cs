using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [SerializeField] private SaveHallway _saveHallway;

    [SerializeField] private TypeScene _typeScene;

    public int id { private get; set; }

    public void SetTypeRenderScene(TypeScene typeScene) => _typeScene = typeScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveCharacter>())
        {
            if (_typeScene != TypeScene.OutRoom && !_saveHallway[id])
            {
                _saveHallway.SetIsOpenDoor(id);
                SceneManager.LoadScene((int)_typeScene);
            }
            else if (_typeScene == TypeScene.OutRoom || _typeScene == TypeScene.Hallway)
            {
                SceneManager.LoadScene(0);
            }

            SetSpawnDoorType();
        }
    }

    private void SetSpawnDoorType()
    {
        switch (_typeScene)
        {
            case TypeScene.Room:
                _saveHallway.TypeSpawnDoor = TypeSpawnDoor.OverideHallway;
                break;
            case TypeScene.Hallway:
                _saveHallway.TypeSpawnDoor = TypeSpawnDoor.NewHallway;
                break;
            case TypeScene.OutRoom:
                _saveHallway.TypeSpawnDoor = TypeSpawnDoor.OverideHallway;
                break;
            default:
                break;
        }
    }
}

public enum TypeScene
{
    Room = 1,
    Hallway = 0,
    OutRoom = 2
}