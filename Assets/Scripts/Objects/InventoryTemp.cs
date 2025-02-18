using Unity.VisualScripting;
using UnityEngine;

public class InventoryTemp : MonoBehaviour
{
    private bool inventoryOpen;
    public CanvasGroup inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        inventory.alpha = 0;
        inventoryOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventoryOpen = true;
            inventory.alpha = 1;
            inventory.interactable = true;
            inventory.blocksRaycasts = true;
        }

        if(inventoryOpen == true && Input.GetKeyDown(KeyCode.Escape))
        {
            inventory.alpha = 0;
            inventory.interactable = false;
            inventory.blocksRaycasts = false;
            inventoryOpen = false;
        }
    }
}
