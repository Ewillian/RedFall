using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOptionController : MonoBehaviour
{
    // Use this for initialization
    public int button_index;
    public string newGameScene;
    public GameObject target;
    public GameObject attachedTo;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;
    private GameObject OptionMenu;
    //private GameObject LoadMenu;
    //private List<GameObject> menuButtons;
    private GameObject MenuController;
    private GameObject OptionController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MenuController = target;
        OptionController = attachedTo;
        //LoadMenu = (GameObject)GameObject.FindGameObjectsWithTag("LoadMenu").GetValue(0);
        //menuButtons = new List<GameObject>();
        //menuButtons.Add(attachedTo.transform.GetChild(0).gameObject);
        //menuButtons.Add(attachedTo.transform.GetChild(1).gameObject);
        //menuButtons.Add(attachedTo.transform.GetChild(2).gameObject);
        //if (attachedTo.name == "MainMenu")
        //{
        //    menuButtons.Add(attachedTo.transform.GetChild(3).gameObject);
        //}

        //foreach (GameObject item in menuButtons)
        //{
        //    Debug.Log(item.name);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (attachedTo.activeInHierarchy == true)
        {
            Debug.Log(button_index);
            if (Input.GetAxis("Vertical") != 0)
            {
                if (!keyDown)
                {
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        if (button_index < maxIndex)
                        {
                            button_index++;
                        }
                        else
                        {
                            button_index = 0;
                        }
                    }
                    else if (Input.GetAxis("Vertical") > 0)
                    {
                        if (button_index > 0)
                        {
                            button_index--;
                        }
                        else
                        {
                            button_index = maxIndex;
                        }
                    }
                    keyDown = true;
                }
            }
            else
            {
                keyDown = false;
            }
            Debug.Log(button_index);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && attachedTo.name == "OptionMenu" && attachedTo.activeInHierarchy == true)
        {
            MenuController.SetActive(true);
            OptionController.SetActive(false);
            button_index = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return) && attachedTo.name == "OptionMenu" && attachedTo.activeInHierarchy == true && button_index == 2)
        {
            Debug.Log(OptionController.name);
            MenuController.SetActive(true);
            OptionController.SetActive(false);
            button_index = 0;
        }
    }

    void ActivateOption()
    {
        Debug.Log("Menu Option");

    }
    void DesactivateOption()
    {
        Debug.Log("Menu Principal");

    }

    void ActivateLoad()
    {
        OptionMenu.SetActive(true);
    }

    void DesactivateLoad()
    {
        OptionMenu.SetActive(false);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}

