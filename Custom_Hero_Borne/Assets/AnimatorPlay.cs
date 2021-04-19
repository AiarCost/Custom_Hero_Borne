using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlay : MonoBehaviour
{

    public Animator animator1;
    public Animator animator2;

    // Start is called before the first frame update
    void Start()
    {
        animator1 = GameObject.Find("PlayButton").GetComponent<Animator>();
        animator2 = GameObject.Find("Title").GetComponent<Animator>();
        animator1.Play("Title_Anim");
        animator2.Play("Battleground_Anim");
        Debug.Log("Animation should work");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
