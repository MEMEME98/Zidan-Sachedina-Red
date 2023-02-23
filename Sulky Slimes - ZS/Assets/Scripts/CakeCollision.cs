using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeCollision : MonoBehaviour
{
    public bool gravity = false;
    GameManager GM;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gravity = true;
        }
    }
}
