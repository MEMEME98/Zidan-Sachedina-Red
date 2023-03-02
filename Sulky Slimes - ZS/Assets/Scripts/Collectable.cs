using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject endingPos;
    private Vector3 initialStartingPosition;
    private Vector3 initialEndingPosition;
    private Vector3 currentStart;
    private Vector3 currentEnd;
    private Vector3 temp;
    public float speed = 0.1f;
    public float direction = 1f;
    public Rigidbody RB;
    public float duration;
    float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialStartingPosition = this.transform.position;
        initialEndingPosition = endingPos.transform.position;
        currentStart = initialStartingPosition;
        currentEnd = initialEndingPosition;
        //RB.AddForce(speed * direction, 0, 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        

        //while(timeElapsed < duration)
        //{
        //    float t = timeElapsed / duration;
        //    transform.position = Vector3.Lerp(currentStart, currentEnd, t);
        //    timeElapsed += Time.deltaTime;
        //}

        float t = timeElapsed / duration;
        transform.position = Vector3.Lerp(currentStart, currentEnd, t);
        timeElapsed += Time.deltaTime;

        if (currentStart == initialStartingPosition && currentEnd == initialEndingPosition)
        {
            temp = initialStartingPosition;
            initialStartingPosition = initialEndingPosition;
            initialEndingPosition = temp;
        }
        else if(currentStart == initialEndingPosition && currentEnd == initialStartingPosition)
        {
            temp = initialEndingPosition;
            initialEndingPosition = initialStartingPosition;
            initialStartingPosition = temp;
        }
        
        if(timeElapsed >= duration)
        {
            timeElapsed = 0;
        }

        //RB.velocity = new Vector3(speed,0,0);
        //if(this.transform.position.x <= endingPosition.x)
        //{
        //    direction = 1f;
        //    RB.AddForce(speed * direction, 0, 0, ForceMode.Impulse);
        //}
        //if (this.transform.position.x >= startingPosition.x)
        //{
        //    direction = -1f;
        //    RB.AddForce(speed * direction, 0, 0, ForceMode.Impulse);
        //}
    }
}
