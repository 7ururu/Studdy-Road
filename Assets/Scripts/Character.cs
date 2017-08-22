using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour {

    private enum Direction {

        Left = 0,
        Forward = 1,
        Right = 2,
    }

    [Header("Animator")]
    [SerializeField]
    private string _idleAnimationName;

    [SerializeField]
    private string _moveForwardAnimationName;

    [SerializeField]
    private string _moveLeftAnimationName;

    [SerializeField]
    private string _moveRightAnimationName;

    [SerializeField]
    private string _moveBackAnimationName;

    private Animator _animator;
    private Direction _direction = Direction.Forward;


    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        if (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash ==
            Animator.StringToHash(_idleAnimationName)) {

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                Move(Direction.Forward);
            } else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                Move(Direction.Left);
            } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
                Move(Direction.Right);
            }
        }
    }

    private void Move(Direction direction) {
        switch (_direction - direction) {
            case 0:
                _animator.Play(_moveForwardAnimationName);
                break;
            case -1:
                _animator.Play(_moveRightAnimationName);
                break;
            case 1:
                _animator.Play(_moveLeftAnimationName);
                break;
            case -2:
            case 2:
                _animator.Play(_moveBackAnimationName);
                break;
        }
        _direction = direction;
    }
}