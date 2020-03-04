using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBehavior : MonoBehaviour
{
    public GameObject button;
    public GameObject starttext;
    public GameObject buttoncover;
    public GameObject titlescreen;
    // Start is called before the first frame update
    IEnumerator fadeout(GameObject obj){
        for (float i = 1; i < 1; i -= 0.01f){

            yield return new WaitForFixedUpdate();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mousePosition.x-Screen.width/2 > button.GetComponent<RectTransform>().rect.width/2){
            button.transform.position = new Vector3(0,Mathf.Lerp(button.transform.position.y,-25,5),0);
        }else{
            button.transform.position = new Vector3(0,Mathf.Lerp(button.transform.position.y,0,5),0);
        }
    }
    public void click(){
        fadeout(titlescreen);
    }
}
