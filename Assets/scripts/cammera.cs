using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class Cammera : MonoBehaviour
{
    private PlayerController _player;
    public Transform transforme;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = FindFirstObjectByType<PlayerController>();
        transforme = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transforme.position = _player.transform.position +new Vector3(0,-_player.transform.position.y,-9);
    }
}
