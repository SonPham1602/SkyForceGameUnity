using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAndFadeOutGameObject : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartFadeIn()
    {
        StartCoroutine("FadeIn");
    }
    public void StartFadeOut()
    {
        StartCoroutine("FadeOut");
    }


    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = spriteRenderer.material.color;
            c.a = f;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1; f > 0; f -= 0.05f)
        {
            Color c = spriteRenderer.material.color;
            c.a = f;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
