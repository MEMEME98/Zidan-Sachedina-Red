using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MouseManager : MonoBehaviour
{
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;

    [Header("Physics")]
    public Vector3 launchVector;
    public float launchForce;

    [Header("Slime")]
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;
    public Transform originalSlimePosition;
    public GameObject slime;

    [Header("Lives")]
    public LiveManager livesManager;

    [Header("Canvas")]
    public TextMeshProUGUI tmp;
    public Button restartButton;
    public TextMeshProUGUI startText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("start", 4);

        if(livesManager.lives > 0)
        {
            tmp.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }
        
        if(livesManager.lives <= 0)
        {
            Invoke("almostDed", 5);
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            //launchVector = new Vector3(mouseDifference.x * 1f, mouseDifference.y * 1.2f, mouseDifference.y * 1.5f);
            launchVector = new Vector3(mouseDifference.x * 1f, mouseDifference.y * 1f, mouseDifference.y * 2f);
            slimeTransform.position = originalSlimePosition.position - launchVector / 400;
            launchVector.Normalize();
        }

        if (Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            slimeRigidbody.AddForce(launchVector * launchForce, ForceMode.Impulse);
            livesManager.RemoveLife();
        }

        if (Input.GetKeyDown("space"))
        {
            slime.transform.position = originalSlimePosition.position;
            slime.transform.rotation = originalSlimePosition.rotation;
            slimeRigidbody.isKinematic = true;
        }

        if(livesManager.lives == 0)
        {
            //ok
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(0);
    }

    public void almostDed()
    {
        tmp.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void start()
    {
        startText.gameObject.SetActive(false);
    }
}
