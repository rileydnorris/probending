using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimationTrigger : MonoBehaviour
{
    public string triggerName;
    void Start()
    {
        Debug.Log("Resetting");
        // animator.SetBool(triggerName, false);
        // animator.gameObject.StartCoroutine(StartDashCooldown());
    }

    IEnumerator StartDashCooldown()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
