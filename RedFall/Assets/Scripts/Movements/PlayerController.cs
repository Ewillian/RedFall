using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Vitesse de déplacement
    public float moveSpeed;

    private Animator anim;
    private bool playerSprinting;
    private bool playerMoving;
    private Vector2 lastMove;
    private SkillController skillController;
    private float collisionTimer = 0;
    public int button_index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;
    public AudioSource audioSource;
    public GameObject Controller;
    public static bool game_is_paused = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        skillController = this.GetComponent<SkillController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(button_index);
        playerMoving = false;
        playerSprinting = false;
        skillController.useSkill();
        pauseMenu();

        if (playerMoving != true)
        {
            // Déplacements horizontaux
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
        }

        if (playerMoving != true)
        {
            // Déplacements verticaux
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
        }

        //Déplacements sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSprinting = true;
            anim.SetBool("PlayerSprinting", playerSprinting);
            moveSpeed *= 3;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerMoving = false;
            playerSprinting = false;
            anim.SetBool("PlayerSprinting", playerSprinting);
            moveSpeed /= 3;
        }



        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);

        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);


        //Corriger les déplacements quand on appuie sur deux touches à la fois
        if (anim.GetFloat("MoveX") == 1 && anim.GetFloat("MoveY") == -1)
        {
            anim.SetFloat("MoveY", 0);
        }

        if (anim.GetFloat("MoveX") == -1 && anim.GetFloat("MoveY") == -1)
        {
            anim.SetFloat("MoveY", 0);

        }

        if (this.collisionTimer > 0)
        {
            collisionTimer -= Time.deltaTime;
            Debug.Log(collisionTimer);
            if (this.collisionTimer <= 0)
            {
                SceneManager.LoadScene("Fight");
            }
        }
    }
    //Collisions
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            this.GetComponent<Animator>().SetBool("PlayerMoving", false);
            this.GetComponent<Animator>().SetBool("Fighting", true);
            this.GetComponent<Animator>().SetBool("activeSkill1", true);
            this.GetComponent<Animator>().SetBool("PlayerSprinting", false);
            this.moveSpeed = 0;
            //attendre puis lancer la scene
            this.collisionTimer = 1.25f;
            if (col.gameObject.name == "Slime")
            {
                Debug.Log("Le monstre est de type Slime");

            }
        }
    }

    public void pauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (game_is_paused == true)
            {
                game_is_paused = false;
                this.Controller.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
                this.Controller.SetActive(true);
                game_is_paused = true;
            }
        }

        if (this.Controller.activeInHierarchy == true)
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

        if (Input.GetKeyDown(KeyCode.Return) && button_index == 0 && this.Controller.activeInHierarchy == true)
        {
            //Resume
            this.Controller.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Return) && button_index == 1 && this.Controller.activeInHierarchy == true)
        {
            //Option
        }
        else if (Input.GetKeyDown(KeyCode.Return) && button_index == 2 && this.Controller.activeInHierarchy == true)
        {
            //Leave
        }
    }

}
