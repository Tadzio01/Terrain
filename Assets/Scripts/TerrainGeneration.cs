using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimplexNoise;

public class TerrainGeneration : MonoBehaviour
{
    private int yScale = 2;
    private int xScale = 5;
    private ArrayList genned = new ArrayList();
    private Transform tparent;
    private GameObject player;
    float noise(int x, float y) {
        return Noise.CalcPixel2D(x,0,1/(y*xScale))/255;
    }
    // Start is called before the first frame update
    void Start() {
        Noise.Seed = 0;
        tparent = GameObject.Find("TerrainHolder").transform;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        int cpos = Mathf.FloorToInt(player.transform.position.x);
        for (int i = cpos-15; i < cpos+15; i++)
        {
            if (!genned.Contains(i)){
                genned.Add(i);
                float pm = 3+3*noise(i,900);
                float om = 35+35*noise(i, 1000);
                float l2 = pm+pm*noise(i, 20);
                float mh = 70+70*noise(i, 40);
                float mmult = (1+noise(i, 500))/2;
                float md = (7*noise(i, 5))*Mathf.Pow(mmult,10f);
                float mm = (mh*(Mathf.Pow(mmult,17)))+md;
                float fd = pm+pm*noise(i, 10);
                int height = Mathf.FloorToInt((fd+om+l2+mm)*yScale);
                float tmult = (100+100*noise(i, 300))/8;
                GameObject topblock = Instantiate(GameObject.Find("TerrainObject"),new Vector3(i, height+1,0),Quaternion.identity);
                topblock.transform.parent = tparent;
                for(int i2 = height; i2 >= 0; i2-=1) {
                    GameObject bblock = Instantiate(GameObject.Find("TerrainObject"),new Vector3(i, i2,0),Quaternion.identity);
                    bblock.transform.parent = tparent;
                }
            }
        }
    }
}
