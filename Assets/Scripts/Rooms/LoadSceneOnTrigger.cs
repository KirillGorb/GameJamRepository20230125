using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [SerializeField] private SaveHallway _saveHallway;

    [SerializeField] private TypeScene _typeScene;

    public void SetTypeRenderScene(TypeScene typeScene) => _typeScene = typeScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveCharacter>())
        {
            SceneManager.LoadScene((int)_typeScene);
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
            default:
                break;
        }
    }
}

public enum TypeScene
{
    Room = 1,
    Hallway = 0
}