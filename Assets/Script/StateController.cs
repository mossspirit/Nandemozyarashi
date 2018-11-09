using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateController : StateMachineBehaviour
{
    SE_controller _audio;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _audio = GameObject.Find("Iris/IrisAudio").GetComponent<SE_controller>();
        
        if (stateInfo.IsName("Aegi"))
        {
            int i = Random.Range(0, 2);
            if (i == 0) _audio.Audio1();
            if (i == 1) _audio.Audio1_3();
        }
        if (stateInfo.IsName("Aegi2"))
        {
            _audio.Audio2();
        }
        if (stateInfo.IsName("Aegi3"))
        {
            _audio.Audio3();
        }
        if(stateInfo.IsName("Aegi4"))
        {
            _audio.Audio1_2();
        }
        if (stateInfo.IsName("Kiss1_1"))
        {
            _audio.KissAudio1_1();
        }
        if (stateInfo.IsName("Kiss1_2"))
        {
            _audio.KissAudio1_2();
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Aegi"))
        {
            animator.SetBool("State1", false);
        }
        if (stateInfo.IsName("Aegi2"))
        {
            animator.SetBool("State2", false);
        }
        if (stateInfo.IsName("Aegi3"))
        {
            animator.SetBool("State3", false);
        }
        if (stateInfo.IsName("Aegi4"))
        {
            animator.SetBool("State4", false);
        }
        if (stateInfo.IsName("Kiss1_2"))
        {
            animator.SetBool("kiss1_2", false);
        }

    }

}