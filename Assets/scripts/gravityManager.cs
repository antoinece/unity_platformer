using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{

    [SerializeField] private bool _upsideDown;
    private SpriteRenderer _sr;
    private GroundedDetector _groundedDetector;
    public bool UpsideDown
    { 
        get
        {
            return _upsideDown;
        }
        
    } 
    private Rigidbody2D _rb;

    private Vector2 _gravityBase;
    // Start is called before the first frame update
    void Start()
    {
        _gravityBase = Physics2D.gravity;
        _sr = GetComponent<SpriteRenderer>();
        _groundedDetector = GetComponent<GroundedDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Space))
        {
            _upsideDown = !_upsideDown;
        }
        Physics2D.gravity = (_upsideDown ? -1 : 1)*_gravityBase;
        
    }
}
