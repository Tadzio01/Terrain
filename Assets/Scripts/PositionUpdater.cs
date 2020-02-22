using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PositionUpdater : MonoBehaviour
{
    private Text txt;
    private GameObject plr;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        plr = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Position: " + Mathf.Round(plr.transform.position.x * 100) / 100 + ", " + Mathf.Round(plr.transform.position.y * 100) / 100;
    }
}
