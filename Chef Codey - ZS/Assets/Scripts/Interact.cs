using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";
    public GameObject breadPrefab;
    public GameObject eggPrefab;
    public GameObject heldItem;
    public string heldItemName;
    public Stove stove;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                PickUpItem(breadPrefab, "breadSlice");
            }

            if(triggerName == "Egg")
            {
                PickUpItem(eggPrefab, "egg");
            }
          
            if (triggerName == "Stove")
            {
                if (heldItemName == "breadSlice")
                {
                    stove.ToastBread();
                    PlaceHeldItem();
                }
                else if(heldItemName == "egg")
                {
                    stove.FryEgg();
                    PlaceHeldItem();
                }
                else
                {
                    if(stove.cookedFood == "toast" && stove.isCooking == false)
                    {
                        PickUpItem(breadPrefab, "toastSlice");
                        stove.CleanStove();
                    }
                    if(stove.cookedFood == "friedEgg" && stove.isCooking == false)
                    {
                        PickUpItem(eggPrefab, "friedEgg");
                        stove.CleanStove();
                    }
                }
            }

            if(triggerName == "Receivers")
            {
                if(heldItemName == "toastSlice")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/French Toast/toastSlice").SetActive(true);
                }
                if(heldItemName == "friedEgg")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/French Toast/friedEgg").SetActive(true);
                }
            }
        }

    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void PickUpItem(GameObject itemPrefab, string itemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0, 4, 2);
        heldItem.transform.localScale = new Vector3(3, 3, 3);
        heldItemName = itemName;
    }

    private void OnTriggerEnter(Collider other)    
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        if(triggerName == other.name)
        {
            triggerName = "";

        }
    }
}
