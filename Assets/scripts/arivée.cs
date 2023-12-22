using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arivee : MonoBehaviour
{
    [SerializeField]
    public bool youWin;
    private DeathDetector _deathDetector;
    // Start is called before the first frame update
    void Start()
    {
        youWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        _deathDetector = FindFirstObjectByType<DeathDetector>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_deathDetector.isDead)
            {
                youWin = true;
            }
        }
    }
}
