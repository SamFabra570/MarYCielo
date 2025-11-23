using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text interactText;
    public GameObject pauseMenu;

    [SerializeField] private MonoBehaviour playerScript;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText()
    {
        interactText.gameObject.SetActive(true);
    }

    public void HideText()
    {
        interactText.gameObject.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        GameManager.instance.isPaused = true;
        
        playerScript.enabled = false;
        pauseMenu.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HidePauseMenu()
    {
        GameManager.instance.isPaused = false;
        
        playerScript.enabled = true;
        pauseMenu.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
