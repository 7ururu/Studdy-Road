using UnityEngine;

public class EffectDisabler : MonoBehaviour {

    [SerializeField]
    private float _time = 5f;

    private float _timer;


    private void OnEnable() {
        _timer = 0f;
    }

    private void Update() {
        _timer += Time.deltaTime;
        if (_timer >= _time) {
            gameObject.SetActive(false);
        }
    }
}