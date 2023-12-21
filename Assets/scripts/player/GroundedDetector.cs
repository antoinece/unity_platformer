using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundedDetector : MonoBehaviour
{
    public bool _isGrounded;
    private GravityManager _gravityManager;
    public Transform transforme;
    private PlayerController _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
    void Start()
    {
        _gravityManager = FindFirstObjectByType<GravityManager>();
        transforme = GetComponent<Transform>();
        _player = FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        if (_gravityManager.UpsideDown)
        {
            transforme.position = _player.transform.position + new Vector3(0,0.9f,0);
        }
        else
        {
            transforme.position = _player.transform.position;
        }
    }
}