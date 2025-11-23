using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Outline outline;
    
    private bool interactable = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //outline = GetComponentInChildren<Outline>();

        if (outline != null)
            outline.enabled = false;
        else
            Debug.LogWarning("No Outline component found");
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //pick up object
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