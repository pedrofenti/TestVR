using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    Animator animator;
    SkinnedMeshRenderer mesh;

    float gripTarget;
    float triggerTarget;
    float gripCurrent;
    float triggerCurrent;

    float axisClickTarget;
    float axisClickCurrent;

    public float speed;

    bool isGrabbing;

    void Start()
    {
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        isGrabbing = false;
    }

    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetAxisTrigger(float v)
    {
        axisClickTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat("Grip", gripCurrent);
        }

        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat("Trigger", triggerCurrent);
        }

        if (axisClickCurrent != axisClickTarget)
        {
            axisClickCurrent = Mathf.MoveTowards(axisClickCurrent, axisClickTarget, Time.deltaTime * speed);
            animator.SetFloat("PrimaryAxisClick", axisClickCurrent);
        }
    }

    public void ToggleVisibilty()
    {
        mesh.enabled = !mesh.enabled;
    }

    public void ActiveGrabbedObject()
    {
        isGrabbing = true;
    }

    public void DeactivateGrabbedObject()
    {
        isGrabbing = false;
    }

    public bool GetIsGrabing()
    {
        return isGrabbing;
    }
}
