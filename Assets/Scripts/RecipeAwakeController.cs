using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecipeAwakeController : MonoBehaviour
{
    [SerializeField] XRGrabInteractable xrController;
    private Animator animator;
    public bool doOnce;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        xrController.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AwakeXRController());
        animator.SetBool("isIdle", false);
        doOnce = true;
    }

    IEnumerator AwakeXRController()
    {
        yield return new WaitForSeconds(1f);
        xrController.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plate" && !doOnce)
        {
            animator.SetBool("isIdle", false);
        }
    }

    public void SetIdle()
    {
        animator.SetBool("isIdle", true);
        doOnce = true;
    }
}
