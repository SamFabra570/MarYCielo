using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Outline outline;
    private bool interactable = false;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        if (outline != null)
            outline.enabled = false;
        else
            Debug.LogWarning("No Outline component found");
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject parent = transform.parent.gameObject;
                if (parent != null)
                {
                    parent.SetActive(false);
                    gameManager.PickUpItem(parent.GetComponent<ObjectController>().id, parent);
                }
                else
                {
                    Debug.Log("This GameObject has no parent.");
                }

                
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UIManager.instance.ShowText();
        
        outline.enabled = true;
        interactable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        UIManager.instance.HideText();
        
        outline.enabled = false;
        interactable = false;
    }
}