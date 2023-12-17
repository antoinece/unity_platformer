using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    private Animator _animator;
    private Rigidbody2D _rb;
    private GroundedDetector _groundedDetector;
    private SpriteRenderer _sr;
    [SerializeField]
    private bool upsideDown;
    private GravityManager _gravityManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundedDetector = GetComponentInChildren<GroundedDetector>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        upsideDown = false;
        _gravityManager = FindFirstObjectByType<GravityManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (_groundedDetector._isGrounded)
        {
            _animator.SetBool("grounded",true);
        }
        else
        {
            _animator.SetBool("grounded",false);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Space))
        {
            upsideDown = !upsideDown;
        }
        _sr.flipY = _gravityManager.UpsideDown;
        // Left Right Movement
        _rb.velocityX = Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") < Mathf.Epsilon*-1&&_groundedDetector._isGrounded||Input.GetAxis("Horizontal") > Mathf.Epsilon&&_groundedDetector._isGrounded)
        {
            _animator.SetBool("isWalking",true);
        }
        else
        {
            _animator.SetBool("isWalking",false);
        }

       
        // Jump
        if (Input.GetAxis("Jump") >= Mathf.Epsilon && _groundedDetector._isGrounded)
        {
            _rb.velocityY = _jumpForce * Time.deltaTime* (_gravityManager.UpsideDown ? -1 : 1) ;
        }   
        if (_rb.velocity.x >= 0.1f)
        {
            _sr.flipX = false;
        }
        else if (_rb.velocity.x <= -0.1f)
        {
            _sr.flipX = true;
        }
    }
}