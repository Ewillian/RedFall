using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField] MenuButton_Controller menuButtonController;
	public bool disableOnce;

	void PlaySound(AudioClip whichSound){
		if(!disableOnce){
            //menuButtonController.audioSource.PlayOneShot (whichSound);
            Debug.Log("bip");
        }
        else{
			disableOnce = false;
		}
	}
}	
