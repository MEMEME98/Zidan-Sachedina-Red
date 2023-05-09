using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public GameObject toast;
    public GameObject friedEgg;
    public string cookedFood = "";
    public ParticleSystem smoke;
    public ParticleSystem complete;

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
    }

    public void ToastBread()
    {
        smoke.Play();
        toast.SetActive(true);
        cookedFood = "toast";
        Invoke("CompleteCooking", 5f);
    }

    public void FryEgg()
    {
        smoke.Play();
        friedEgg.SetActive(true);
        cookedFood = "friedEgg";
        Invoke("CompleteCooking", 8f);
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
        cookedFood = "";
    }

    private void CompleteCooking()
    {
        smoke.Stop();
        complete.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
