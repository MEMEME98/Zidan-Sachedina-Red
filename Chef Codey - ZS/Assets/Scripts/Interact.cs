using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";
    public GameObject breadPrefab;
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
            if(triggerName == "Bread")
            {
                heldItem = Instantiate(breadPrefab, transform, false);
                heldItem.transform.localPosition = new Vector3(0, 4, 2);
                heldItem.transform.localScale = new Vector3(3, 3, 3);
                heldItemName = "breadSlice";
            }

            if(triggerName == "Stove")
            {
                print("Im at the stove!");
                if(heldItemName == "breadSlice")
                {
                    stove.ToastBread();
                    Destroy(heldItem.gameObject);
                    heldItemName = "";
                }
                else
                {
                    print("Codey is empty handed!");
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }
}
