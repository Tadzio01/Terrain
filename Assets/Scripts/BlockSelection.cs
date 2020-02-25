using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlockSelection : MonoBehaviour
{
    public Camera cam;
    void Update(){
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            GameObject target2 = hit.collider.gameObject;
            Ray ray2 = new Ray(transform.position, target2.transform.position-transform.position);
            RaycastHit hit2;
            if(Physics.Raycast(ray2, out hit2)){
                GameObject target = hit2.collider.gameObject;
                if((target.transform.position-transform.position).magnitude < 5){
                    
                    if (Input.GetMouseButtonDown(0)) {
                        Destroy(target);
                    }
                }
            }
        }
    }
}