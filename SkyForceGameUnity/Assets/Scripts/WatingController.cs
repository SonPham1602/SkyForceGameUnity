using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class WatingController : MonoBehaviour
{
    public Text loadingText;
    private string dot = "";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoCheck());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(DoCheck());
    }


    IEnumerator DoCheck() {
        for(;;){
            if(dot.Length < 3){
                dot += ".";
            }else{
                dot = "";
            }
            loadingText.text = "Loading" + dot;
            yield return new WaitForSecondsRealtime(0.4f);
        }
        
    }
}
