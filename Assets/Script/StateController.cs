using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateController : StateMachineBehaviour
{
    SE_controller _audio;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _audio = GameObject.Find("[CameraRig]").GetComponent<SE_controller>();

        /*if (stateInfo.IsName("wait"))
        {
            _audio.Wait_SE();
        }
        if (stateInfo.IsName("walk"))
        {
            _audio.Walk_SE();
        }*/
        if (stateInfo.IsName("zyare1"))
        {
            _audio.Zyare1_SE();
        }
        if(stateInfo.IsName("zyare2"))
        {
            _audio.Zyare2_SE();
        }
        if (stateInfo.IsName("zyare3") || stateInfo.IsName("jump"))
        {
            _audio.Zyare3_SE();
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("walk") || stateInfo.IsName("zyare1") || stateInfo.IsName("zyare2") || stateInfo.IsName("zyare3") || stateInfo.IsName("jump"))
        {
            _audio.SE_flag_true();
        }

    }

}