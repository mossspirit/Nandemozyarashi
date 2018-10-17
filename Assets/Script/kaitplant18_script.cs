using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaitplant18_script : MonoBehaviour {

    private GameObject Nekojarashi;
    private Animator animator;
    private bool nekojarashi_flag;
    private int i = 0;

	void Start () {
        animator = GetComponent<Animator>();
        Nekojarashi = GameObject.Find("nekojarashi1_set");
	}
	
	// Update is called once per frame
	void Update () {
        nekojarashi_flag = Nekojarashi.GetComponent<nekojarasi>().nekojarashi_flag;
        if (nekojarashi_flag)
        {
            if (i == 0)
            {
                animator.SetTrigger("taiki_to_jump");
                i++;
            }
            else if (i == 1)
            {
                animator.SetTrigger("jump_to_walk");
                i++;
            }
            else if (i == 2)
            {
                animator.SetTrigger("walk_to_atacck1");
                i++;
            }
        }
        else;

    }
}
