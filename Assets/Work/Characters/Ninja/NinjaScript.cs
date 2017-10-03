using System.Collections;
using UnityEngine;

public class NinjaScript : Character {

    [SerializeField]
    private GameObject _smokePrefab;

    [SerializeField]
    private float _delay = 0.5f;

    private GameObject[] _smokes;


    protected override void Awake() {
        base.Awake();
        if (_smokePrefab != null) {
            _smokes = new GameObject[10];
            for (int i = 0; i < _smokes.Length; i++) {
                _smokes[i] = Instantiate(_smokePrefab, Vector3.zero, Quaternion.Euler(-90f, 0f, 0f));
                _smokes[i].SetActive(false);
            }
        }
    }

    public override void MakeAction() {
        base.MakeAction();
        if (_smokePrefab != null) {
            StartCoroutine(ActivateSmoke());
        }
    }

    private IEnumerator ActivateSmoke() {
        yield return new WaitForSeconds(_delay);
        for (int i = 0; i < _smokes.Length; i++) {
            if (!_smokes[i].activeSelf) {
                _smokes[i].transform.position = transform.position;
                _smokes[i].SetActive(true);
                break;
            }
        }
    }
}