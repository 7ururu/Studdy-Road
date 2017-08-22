using UnityEngine;

public class GameCamera : MonoBehaviour {

    [SerializeField]
    private Character _character;

    [SerializeField]
    private float _smoothTime = 0.1f;

    [SerializeField]
    private float _maxSpeed = 1f;

    private Vector3 _velocity;


    private void LateUpdate() {
        var p = new Vector3(_character.transform.position.x, transform.position.y, 
                            _character.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, p, ref _velocity, 
                                                _smoothTime, _maxSpeed, Time.deltaTime);
    }
}