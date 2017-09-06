using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    [SerializeField]
    private GameCamera _gameCamera;

    private Character _character;


    private void Awake() {
        var prefab = Config.Instance.characters[Mathf.Min(Settings.SelectedCharacterIndex, Config.Instance.characters.Length - 1)];
        _character = Instantiate(prefab, Vector3.zero, Quaternion.identity);

        _gameCamera.Target = _character;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            _character.Move(Character.Direction.Forward);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            _character.Move(Character.Direction.Left);
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            _character.Move(Character.Direction.Right);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            _character.Move(Character.Direction.Back);
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            _character.MakeAction();
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(Config.Instance.menuSceneName);
        }
    }
}