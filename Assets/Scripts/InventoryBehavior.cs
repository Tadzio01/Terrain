using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;
using UnityEngine.UI;

public class InventoryBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform slot in transform){
            int sn = int.Parse(slot.name.Substring(4));
            GameObject container = slot.GetChild(0).gameObject;
            GameObject counter = slot.GetChild(1).gameObject;
            string[] ic = inv.content[sn-1].Split(',');
            int id = int.Parse(ic[0]);
            int ct = int.Parse(ic[1]);
            if (ct == 0 || id == 0){
                container.SetActive(false);
                counter.SetActive(false);
            }else{
                container.SetActive(true);
                counter.SetActive(true);
                container.GetComponent<Image>().color = inv.getColor(id);
                if (ct < 2){
                    counter.GetComponent<Text>().text = "";
                }else{
                    counter.GetComponent<Text>().text = ct.ToString();
                }
            }
            if (sn == inv.current){
                slot.GetComponent<Image>().color = new Color(1,1,1);
            }else{
                slot.GetComponent<Image>().color = new Color(0.5f,0.5f,0.5f,0.5f);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f){
            inv.current += (int)-(Input.GetAxis("Mouse ScrollWheel")*10);
            if(inv.current > 10){
                inv.current = 1;
            }else if(inv.current < 1){
                inv.current = 10;
            }
        }
    }
}
