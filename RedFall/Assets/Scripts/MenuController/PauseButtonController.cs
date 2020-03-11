using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour
{

    // Use this for initialization
    public int button_index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;
    public GameObject Controller;
    public static bool game_is_paused = false;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        Controller.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(game_is_paused == true)
            {

            }
            else
            {
                Debug.Log("ICI");
                Controller.SetActive(true);
                game_is_paused = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) && button_index == 0 && Controller.activeInHierarchy == true)
        {
            //Resume
            Controller.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Return) && button_index == 1 && Controller.activeInHierarchy == true)
        {
            //Option
        }
        else if (Input.GetKeyDown(KeyCode.Return) && button_index == 2 && Controller.activeInHierarchy == true)
        {
            //Leave
        }



        if (Controller.activeInHierarchy == true)
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
    }
}
