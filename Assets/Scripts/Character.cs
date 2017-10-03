using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour {

    public enum Direction {

        Left = 0,
        Forward = 1,
        Right = 2,
        Back = 3,
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

    [SerializeField]
    private string _actionAnimationName;

    private Animator _animator;
    private Direction _direction = Direction.Forward;


    protected virtual void Awake() {
        _animator = GetComponent<Animator>();
    }

    public virtual void Move(Direction direction) {
        if (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash(_idleAnimationName)) {
            return;
        }
        switch (_direction - direction) {
            case 0:
                _animator.Play(_moveForwardAnimationName);
                break;
            case -1:
            case 3:
                _animator.Play(_moveRightAnimationName);
                break;
            case 1:
            case -3:
                _animator.Play(_moveLeftAnimationName);
                break;
            case -2:
            case 2:
                _animator.Play(_moveBackAnimationName);
                break;
        }
        _direction = direction;
    }

    public virtual void MakeAction() {
        if (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash(_idleAnimationName)) {
            return;
        }
        _animator.Play(_actionAnimationName);
    }
}