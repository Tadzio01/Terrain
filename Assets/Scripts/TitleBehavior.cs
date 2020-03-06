using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBehavior : MonoBehaviour
{
    public GameObject button;
    public GameObject starttext;
    public GameObject buttoncover;
    public GameObject titlescreen;
    public GameObject tcover;
    private Vector3 pos;
    private bool fade = false;
    private bool fade2 = false;
    // Start is called before the first frame update
    private IEnumerator c(){
        tcover.SetActive(true);
        fade = true;
        yield return new WaitForSeconds(0.5f);
        fade = false;
        titlescreen.SetActive(false);
        fade2 = true;
        yield return new WaitForSeconds(0.5f);
        tcover.SetActive(false);
    }
    void Start()
    {
        pos = button.transform.position;
    }
    public void click(){
        StartCoroutine(c());
    }

    // Update is called once per frame
    void Update()
    {
        if((new Vector3(Input.mousePosition.x,0,0)-new Vector3(Screen.width/2,0,0)).magnitude < 160){
            button.transform.position = new Vector3(pos.x,Mathf.Lerp(button.transform.position.y,pos.y-55,5*Time.deltaTime),0);
            starttext.transform.position = new Vector3(pos.x,Mathf.Lerp(starttext.transform.position.y,pos.y+55,5*Time.deltaTime),0);
            buttoncover.transform.position = starttext.transform.position;
        }else{
            button.transform.position = new Vector3(pos.x,Mathf.Lerp(button.transform.position.y,pos.y,5*Time.deltaTime),0);
            starttext.transform.position = new Vector3(pos.x,Mathf.Lerp(starttext.transform.position.y,pos.y,5*Time.deltaTime),0);
            buttoncover.transform.position = starttext.transform.position;
        }
        if(fade){
            tcover.GetComponent<Image>().color = new Color(0,0,0,Mathf.Lerp(tcover.GetComponent<Image>().color.a,1,10*Time.deltaTime));
        }else if(fade2){
            tcover.GetComponent<Image>().color = new Color(0,0,0,Mathf.Lerp(tcover.GetComponent<Image>().color.a,0,10*Time.deltaTime));
        }
    }
}
