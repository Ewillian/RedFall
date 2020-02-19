using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.GetBool("Fighting");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void useSkill()
    {
        if (anim.GetBool("Fighting") == true)
        {
            //Compétence 1 - Epée 1
            manageInputSkill("activeSkill1", KeyCode.Alpha1);

        }
    }

    public void manageInputSkill(string value, KeyCode input)
    {
        if (Input.GetKeyDown(input))
        {
            anim.SetBool(value, true);

        }
        if (Input.GetKeyUp(input))
        {
            anim.SetBool(value, false);

        }
    }
}
