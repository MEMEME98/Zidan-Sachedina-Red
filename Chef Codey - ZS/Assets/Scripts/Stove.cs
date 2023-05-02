using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public GameObject toast;
    public GameObject friedEgg;
    public string cookedFood = "";
    
    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
    }

    public void ToastBread()
    {
        toast.SetActive(true);
        cookedFood = "toast";
    }

    public void FryEgg()
    {
        friedEgg.SetActive(true);
        cookedFood = "friedEgg";
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
        cookedFood = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
