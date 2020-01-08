using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton_Controller : MonoBehaviour
{
    // Use this for initialization
    public int index;
    public int indexOption;
    public string newGameScene;
    public Button enterButton;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;
    private GameObject OptionMenu;
    //private GameObject LoadMenu;
    private List<GameObject> menuButtons;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        OptionMenu = (GameObject)GameObject.FindGameObjectsWithTag("OptionMenu").GetValue(0);
        Debug.Log(OptionMenu);
        //LoadMenu = (GameObject)GameObject.FindGameObjectsWithTag("LoadMenu").GetValue(0);
        OptionMenu.SetActive(false);
        menuButtons = new List<GameObject>();
        menuButtons.Add((GameObject)GameObject.FindGameObjectsWithTag("MainMenu").GetValue(0));
        menuButtons.Add((GameObject)GameObject.FindGameObjectsWithTag("MainMenu").GetValue(1));
        menuButtons.Add((GameObject)GameObject.FindGameObjectsWithTag("MainMenu").GetValue(2));
        menuButtons.Add((GameObject)GameObject.FindGameObjectsWithTag("MainMenu").GetValue(3));

        foreach (GameObject item in menuButtons)
        {
            Debug.Log(item.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }

        if (menuButtons[0].activeInHierarchy == false && OptionMenu.activeInHierarchy == true)
        {
            Debug.Log("OptionMovement");
            if (Input.GetAxis("Vertical") != 0)
            {
                Debug.Log("OptionMovement2");
                if (!keyDown)
                {
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        if (indexOption < maxIndex)
                        {
                            indexOption++;
                        }
                        else
                        {
                            indexOption = 0;
                        }
                    }
                    else if (Input.GetAxis("Vertical") > 0)
                    {
                        if (indexOption > 0)
                        {
                            indexOption--;
                        }
                        else
                        {
                            indexOption = maxIndex;
                        }
                    }
                    keyDown = true;
                }
            }
            else
            {
                keyDown = false;
            }
        }

        //Nouvelle partie
        if (Input.GetKeyDown(KeyCode.Return) && index == 0)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Return) && index == 1)
        {
            Debug.Log("Menu Chargement");
        }

        if (Input.GetKeyDown(KeyCode.Return) && index == 2)
        {
            ActivateOption();
        }

        if (menuButtons[0].activeInHierarchy == false && Input.GetKeyDown(KeyCode.Escape))
        {
            DesactivateOption();
        }
    }

    void ActivateOption()
    {
        Debug.Log("Menu Option");
        OptionMenu.SetActive(true);
        foreach (GameObject menuContent in menuButtons)
        {
            menuContent.SetActive(false);
        }
    }
    void DesactivateOption()
    {
        Debug.Log("Menu Principal");
        OptionMenu.SetActive(false);
        foreach (GameObject menuContent in menuButtons)
        {
            menuContent.SetActive(true);
        }
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
