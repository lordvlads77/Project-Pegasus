using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = default;
    [SerializeField] private int _jumpSpeed = default;
    [SerializeField] public GameObject _screenPause = default;
    [SerializeField] private KeyCode _horizontalL = default;
    [SerializeField] private KeyCode _horizontalR = default;
    [SerializeField] private KeyCode _jumpL = default;
    [SerializeField] private KeyCode _pause = default;

    [Header("Animation Stuff")]
    [SerializeField] private Animator _animator = default;
    private readonly int _ahSpeed = Animator.StringToHash("speed");
    private readonly int _ahJump = Animator.StringToHash("jump");

    [Header("CheckGround")]
    [FormerlySerializedAs("checkgroundPosition")] [SerializeField] private Vector3 _checkgroundPosition = default;
    [FormerlySerializedAs("isGround")] [SerializeField] private bool _isGround = default;
    [FormerlySerializedAs("checkGroundRatio")] [SerializeField] private float _checkGroundRatio = default;
    [FormerlySerializedAs("checkGroundMask")] [SerializeField] private LayerMask _checkGroundMask = default;

    [Header("Cosas del Salto")] 
    [SerializeField] private Rigidbody _rigidbody = default;
    private Vector3 movement = default;

    private void FixedUpdate()
    {
        movement = transform.TransformDirection(movement);
        _isGround = Physics.CheckSphere(transform.position + _checkgroundPosition, _checkGroundRatio, _checkGroundMask);
        movement.y = _rigidbody.velocity.y;
        _rigidbody.velocity = movement;
    }

    void Update()
    {
        if (Input.GetKey(_horizontalL))
        {
            Move(-1);
            _animator.SetInteger(_ahSpeed, 2);
        }
        if (Input.GetKeyUp(_horizontalL))
        {
            _animator.SetInteger(_ahSpeed, 1);
        }
        if (Input.GetKey(_horizontalR))
        {
            Move(1);
            _animator.SetInteger(_ahSpeed, 4);
        }
        if (Input.GetKeyDown(_jumpL) && _isGround)
        {
            Jump();
            _animator.SetTrigger(_ahJump);
        }
        if (Input.GetKeyDown(_pause))
        {
            Pause();
        }
        if (Input.GetKeyUp(_horizontalR))
        {
            _animator.SetInteger(_ahSpeed, 0);
        }
    }

    public void Move(int direction)
    {
        transform.Translate(0, 0, direction * _speed * Time.deltaTime);
    }
    
    public void Jump()
    {   
        _rigidbody.AddForce(Vector3.up * _jumpSpeed);
    }

    public void Pause()
    {
        _screenPause.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + _checkgroundPosition, _checkGroundRatio);
    }
}
