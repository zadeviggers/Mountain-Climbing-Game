using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentGameobjectOnAnimationstateExit : StateMachineBehaviour
{
    // Called when this state is exited
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.transform.parent.gameObject);
    }
}
