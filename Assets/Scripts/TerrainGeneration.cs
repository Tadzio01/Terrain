using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimplexNoise;
using UnityEditor;

public class TerrainGeneration : MonoBehaviour
{
    public GameObject grass;
    public GameObject dirt;
    private int yScale = 1;
    private int xScale = 3;
    private ArrayList genned = new ArrayList();
    private Transform tparent;
    private GameObject player;
    private float sealevel = 25;
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
        for (int i = cpos-20; i < cpos+20; i++)
        {
            if (!genned.Contains(i)){
                genned.Add(i);
                float pm = 3+3*noise(i,900);
                float om = 35+35*noise(i, 1000);
                float l2 = pm+pm*noise(i, 20);
                float mh = 90+90*noise(i, 40);
                float mmult = (1+noise(i, 500))/2;
                float md = (7*noise(i, 5))*Mathf.Pow(mmult,10f);
                float mm = (mh*(Mathf.Pow(mmult,17)))+md;
                float fd = pm+pm*noise(i, 10);
                int height = Mathf.FloorToInt((fd+om+l2+mm)*yScale);
                float tmult = (100+100*noise(i, 300))/10;
                GameObject topblock = Instantiate(grass,new Vector3(i, height+1,0),Quaternion.identity);
                topblock.transform.parent = tparent;
                if(height > sealevel){
                    for(int i2 = height; i2 >= 0; i2-=1) {
                        GameObject bblock = Instantiate(dirt,new Vector3(i, i2,0),Quaternion.identity);
                        bblock.transform.parent = tparent;
                    }
                    if (Random.Range(0,10000)/100 < tmult){
                        Instantiate(Resources.Load("Tree"+Random.Range(1,4)),new Vector3(i,height+1,0),Quaternion.identity);
                    }
                }
            }
        }
    }
}
