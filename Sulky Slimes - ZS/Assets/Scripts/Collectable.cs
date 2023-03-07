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


    public AnimationCurve benny;
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

        duration += Time.deltaTime;
        transform.position = Vector3.Lerp(currentStart, currentEnd, benny.Evaluate(duration));

        //float t = timeElapsed / duration;
        //transform.position = Vector3.Lerp(currentStart, currentEnd, t);
        //timeElapsed += Time.deltaTime;

        //if (t == 1)
        //{
        //    transform.position = Vector3.Lerp(currentStart, currentEnd, t);
        //    if (timeElapsed >= duration)
        //    {
        //        timeElapsed = 0;
        //    }
        //}
        //else if (t == 0)
        //{
        //    transform.position = Vector3.Lerp(currentEnd, currentStart, t);

        //    if (timeElapsed >= duration)
        //    {
        //        timeElapsed = 1;
        //    }
        //}

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
