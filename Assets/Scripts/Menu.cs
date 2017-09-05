using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    
    [SerializeField]
    private float _padding = 1.5f;

    [SerializeField]
    private float _smoothTime = 0.2f;

    [SerializeField]
    private float _maxSpeed = 10f;

    [SerializeField]
    private Vector3 _postion;

    [SerializeField]
    private Vector3 _rotation;


    private Character[] _characters;
    private Vector3[] _velocities;
    private int _selectedCharacterIndex;


    private void Awake() {
        _selectedCharacterIndex = Settings.SelectedCharacterIndex;
        _characters = new Character[Config.Instance.characters.Length];
        for (int i = 0; i < _characters.Length; i++) {
            _characters[i] = Instantiate(Config.Instance.characters[i]);
            _characters[i].transform.position = GetTargetPosition(i);
            _characters[i].transform.eulerAngles = _rotation;
        }
        _velocities = new Vector3[_characters.Length];
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            _selectedCharacterIndex = Mathf.Max(0, _selectedCharacterIndex - 1);
            Settings.SelectedCharacterIndex = _selectedCharacterIndex;
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            _selectedCharacterIndex = Mathf.Min(_characters.Length - 1, _selectedCharacterIndex + 1);
            Settings.SelectedCharacterIndex = _selectedCharacterIndex;
        } else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(Config.Instance.defaultLevelSceneName);
        }
        UpdatePositions();
    }

    private void UpdatePositions() {
        for (int i = 0; i < _characters.Length; i++) {
            _characters[i].transform.position = Vector3.SmoothDamp(_characters[i].transform.position,
                                                                   GetTargetPosition(i), ref _velocities[i],
                                                                   _smoothTime, _maxSpeed, Time.deltaTime);
        }
    }

    private Vector3 GetTargetPosition(int index) {
        return new Vector3(_postion.x + _padding * (index - _selectedCharacterIndex), _postion.y, _postion.z);
    }
}