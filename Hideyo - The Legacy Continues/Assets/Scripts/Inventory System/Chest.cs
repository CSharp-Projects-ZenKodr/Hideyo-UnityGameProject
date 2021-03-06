﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Item[] itemsToAdd;
    private Player player;
    private InventoryManager inventoryManager;
    private Inventory inventory = new Inventory(24);
    public AudioSource openCloseInventoryAudioSource;

    [SerializeField]
    private GameObject OpenContainerText;
    bool check = false;
    void Start ()
    {
        player = FindObjectOfType<Player>();
        inventoryManager = InventoryManager.INSTANCE;
          foreach (Item item in itemsToAdd)
        {
            inventory.addItem(new ItemStack(item, 1));
        }
    }


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance<4 && !inventoryManager.hasInventoryCurrentlyOpen())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                inventoryManager.openContainer(new ContainerChest(inventory, player.getInventory()));
                check = true;
            openCloseInventoryAudioSource.Play();
            }

        }
        else
        {
            if ((Input.GetKeyDown(KeyCode.E) && inventoryManager.hasInventoryCurrentlyOpen()) && check==true)
            {
            openCloseInventoryAudioSource.Play();
                inventoryManager.closeContainer();
                check = false;
            }

        }
        // if (distance > 4)
        // {
        //     OpenContainerText.gameObject.SetActive(false);
        // }
    }
}