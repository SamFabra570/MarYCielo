using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int onHandItem; //Item that the player just picked up, -1 when nothing in hand
    public GameObject onHandItemObject; //Item that the player just picked up, -1 when nothing in hand
    public int activeItem; //Item that is currently being searched
    public int lifes;
    public int[] inventory; //Inventory of the delivered items, 1 when the player delivers an item
    public bool isPaused = false;

    [SerializeField] private MonoBehaviour playerScript;
    public GameObject tutorial;
    
    void Awake()
    {
        if (instance == null)
        {
            onHandItem = -1;
            activeItem = 1;
            int i = 0;
            //initialize with -1
            inventory = new int[20];
            while (i < 20)
            {
                inventory[i] = -1;
                i++;
            }
            //initialize the players inventory
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(instance);
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            UIManager.instance.ShowPauseMenu();
        }
    }

    //The player picks up an item
    public void PickUpItem(int item, GameObject itemObject)
    {
        onHandItemObject = itemObject;
        onHandItem = item;
    }

    //The player picks up an item
    public void DeliverItem()
    {
        if (onHandItem == activeItem)
        {
            inventory[onHandItem] = 1;
            onHandItem = -1;
        }
        else {
            onHandItemObject.SetActive(true);
            lifes--;
        }
        
    }

    //Depending of the state of each item, an ending is chosen. 
    public int EvaluateEnding()
    {
        int sum = 0;
        int i = 0;
        while (i < 8)
        {
            sum += inventory[i];
            i++;
        }
        return sum;
    }

    public int Ending()
    {
        int sum = 0;
        int i = 0;
        while (i < 8)
        {
            sum += inventory[i];
            i++;
        }
        return sum;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        //EditorApplication.ExitPlaymode();
        Application.Quit();
    }

    public void CloseTutorial()
    {
        tutorial.SetActive(false);
        playerScript.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}