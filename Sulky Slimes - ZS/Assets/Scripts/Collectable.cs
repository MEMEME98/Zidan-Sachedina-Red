using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float distanceToMove;
    public GameObject endingPos;
    private Vector3 startingPosition;
    private Vector3 endingPosition;
    public float speed = 0.1f;
    public float direction = 1f;
    public Rigidbody RB;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;
        endingPos.transform.position = endingPosition;
        RB.AddForce(speed * direction, 0, 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector3(speed,0,0);
        if(this.transform.position.x <= endingPosition.x)
        {
            direction = 1f;
            RB.AddForce(speed * direction, 0, 0, ForceMode.Impulse);
        }
        if (this.transform.position.x >= startingPosition.x)
        {
            direction = -1f;
            RB.AddForce(speed * direction, 0, 0, ForceMode.Impulse);
        }
    }
}
