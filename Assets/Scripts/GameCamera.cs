using UnityEngine;

public class GameCamera : MonoBehaviour {

    [SerializeField]
    private float _smoothTime = 0.1f;

    [SerializeField]
    private float _maxSpeed = 1f;

    public Character Target { get; set; }

    private Vector3 _velocity;


    private void LateUpdate() {
        if (Target == null) {
            return;
        }
        var p = new Vector3(Target.transform.position.x, transform.position.y,
                            Target.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, p, ref _velocity, 
                                                _smoothTime, _maxSpeed, Time.deltaTime);
    }
}