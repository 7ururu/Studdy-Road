using UnityEngine;

public class PenguinScript : Character {

    [SerializeField]
    private GameObject _iceTrailPrefab;

    private GameObject[] _iceTrails;
    private int _currentTrail;


    protected override void Awake() {
        base.Awake();

        _iceTrails = new GameObject[10];
        for (int i = 0; i < _iceTrails.Length; i++) {
            _iceTrails[i] = Instantiate(_iceTrailPrefab);
            _iceTrails[i].SetActive(false);
        }
        _currentTrail = 0;
    }

    public void EnableIceTrail() {
        _iceTrails[_currentTrail].SetActive(true);
    }

    public void DisableIceTrail() {
        _currentTrail = (_currentTrail + 1) % _iceTrails.Length;
    }

    private void LateUpdate() {
        var t = _iceTrails[_currentTrail];
        t.transform.position = new Vector3(transform.position.x, 0.01f, transform.position.z);
        t.transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, 0f);
    }
}