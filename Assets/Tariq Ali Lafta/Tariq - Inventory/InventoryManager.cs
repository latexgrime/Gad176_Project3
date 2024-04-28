using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.GAD176.Project3.TariqAliLafta.Inventory.Manager
{
    public class InventoryManager : MonoBehaviour
    {

        public GameObject inventorymenu;
        private bool menuactivated;

        // Update is called once per frame
        void Update()
        {
        //stops time when pressing E to activate the inventory.
            if (Input.GetKeyDown(KeyCode.E) && menuactivated) 
            {
                Time.timeScale = 1;
                inventorymenu.SetActive(false);
                menuactivated = false;
            }
//resumes time when repressing the E button to continue the gameplay.
            else if (Input.GetKeyDown(KeyCode.E) && !menuactivated)
            {
                Time.timeScale = 0;
                inventorymenu.SetActive(true);
                menuactivated = true;
            }

        }

        public void AddItem(string ItemName, int quantity, Sprite itemsprite) 
        {
             Debug.Log ("itemName" +  ItemName + "quantity =" + quantity + "itemSprite" + itemsprite);
        }
    }
}
