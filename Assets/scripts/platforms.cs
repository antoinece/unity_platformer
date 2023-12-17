using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    private PlayerController _player;
     
    private GravityManager _gravityManager;
    private BoxCollider2D _collider2D;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<PlayerController>();
        _gravityManager = FindFirstObjectByType<GravityManager>();
        _collider2D = GetComponent<BoxCollider2D>();
    }
    

    // Update is called once per frame
    void Update()
    {

        if (_player.transform.position.y -transform.position.y> 0.6f * (_gravityManager.UpsideDown ? -1 : 1) )
        {
            if (_gravityManager.UpsideDown)
            {
                _collider2D.enabled = false;
            }
            else
            {
                _collider2D.enabled = true;
            }
        }
        else
        { 
            if (_gravityManager.UpsideDown)
            {
                _collider2D.enabled = true;
            }
            else
            {
                _collider2D.enabled = false;
            }
        }
        
       
    }
}
