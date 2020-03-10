using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory;
public class BlockSelection : MonoBehaviour
{
    public Camera cam;
    private GameObject outline;
    void Start() {
        outline = GameObject.Find("BlockOutline");
    }
    void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)  && hit.transform != transform) {
            GameObject target2 = hit.collider.gameObject;
            Ray ray2 = new Ray(transform.position+new Vector3(0,0.5f,0), target2.transform.position-transform.position);
            if (Physics.Raycast(ray2, out RaycastHit hit2) && hit.transform != transform) {
                GameObject target = hit2.collider.gameObject;
                if ((target.transform.position - transform.position).magnitude < 5){
                    outline.transform.position = target.transform.position;
                    if (Input.GetMouseButtonDown(0)) {
                        inv.add(inv.getID(target.GetComponent<Material>().color));
                        Destroy(target);
                        outline.transform.position = Vector3.down * 5000;
                    }
                    return;
                }
                return;
            }
            return;
        }
        outline.transform.position = Vector3.down * 5000;
    }
}