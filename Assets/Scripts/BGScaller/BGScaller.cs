using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;
        float width = sr.bounds.size.x;

        float worldWidth = Camera.main.orthographicSize * 2f;
        float worldHeight = worldWidth * Screen.height / Screen.width;
        tempScale.x = worldWidth / width;
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
