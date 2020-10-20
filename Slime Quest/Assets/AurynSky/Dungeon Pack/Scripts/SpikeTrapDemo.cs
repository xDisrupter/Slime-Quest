using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;

    public Animator spikeTrapAnim; //Animator for the SpikeTrap;
    public bool takeDmg;
    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        takeDmg = false;
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 2 seconds;
        takeDmg = true;
        yield return new WaitForSeconds(2);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        takeDmg = false;
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //Do it again;
        StartCoroutine(OpenCloseTrap());

    }



}