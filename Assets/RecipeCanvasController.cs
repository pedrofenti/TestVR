using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCanvasController : MonoBehaviour
{
    [SerializeField] Image timer; //esto es la imagen
    [SerializeField] float counter;

    // Start is called before the first frame update
    void Start()
    {
        //y aqui hacer el Lerp supongo

    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime / 10;
        timer.fillAmount = Mathf.Lerp(0, 1, counter); // uwu

        if (timer.fillAmount <= 0) Destroy(gameObject);
    }
}
