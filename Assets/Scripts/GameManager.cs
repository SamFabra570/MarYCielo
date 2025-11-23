using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int onHandItem; //Item that the player just picked up, -1 when nothing in hand
    public int activeItem; //Item that is currently being searched
    public int lifes;
    public int[] inventory; //Inventory of the delivered items, 1 when the player delivers an item

    public bool isPaused = false;
    
    void Awake()
    {
        if (instance == null)
        {
            onHandItem = -1;
            activeItem = 0;
            int i = 0;
            //initialize with 0
            inventory = new int[20];
            while (i < 20)
            {
                inventory[i] = 0;
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
    public void PickUpItem(int item)
    {
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

    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}