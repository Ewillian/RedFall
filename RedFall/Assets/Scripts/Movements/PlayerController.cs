﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    // Vitesse de déplacement
    public float moveSpeed;

    private Animator anim;

    private bool playerMoving;
    private Vector2 lastMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;

        if(playerMoving != true) { 
        // Déplacements horizontaux
            if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
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

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);

        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);


        //Corriger les déplacements quand on appuie sur deux touches à la fois
        if(anim.GetFloat("MoveX") == 1 && anim.GetFloat("MoveY") == -1)
        {
            anim.SetFloat("MoveY", 0);
        }

        if(anim.GetFloat("MoveX") == -1 && anim.GetFloat("MoveY") == -1)
        {
            anim.SetFloat("MoveY", 0);
        }
    }
}