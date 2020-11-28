
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera mainCamera;
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;
    private Vector2 _mousePosition;
    private Animator _animator;
     

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        //movementInput
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y =Input.GetAxisRaw("Vertical");
        
        // _animator.SetFloat("Horizontal", _movement.x);
        // _animator.SetFloat("Vertical", _movement.y);
        // _animator.SetFloat("Speed", _movement.sqrMagnitude);
        
        //retrieving mouse position
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        _mousePosition = mainCamera.ScreenToWorldPoint(mousePos);
    }

    private void FixedUpdate()
    {
        //movement
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movement * (moveSpeed * Time.fixedDeltaTime));
        
        //rotation
        var mouseDirection = _mousePosition - _rigidbody2D.position;
        var angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg - 90;
        _rigidbody2D.rotation = angle;
    }
}
