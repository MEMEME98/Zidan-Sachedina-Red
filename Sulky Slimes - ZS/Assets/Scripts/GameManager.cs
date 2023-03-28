using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int lives;
    public GameObject[] hearts;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLife()
    {
        lives -= 1;
        print("You lost a life! Lives: " + lives);
    }

    public void random()
    {
        SceneManager.LoadScene(1);
    }
}
