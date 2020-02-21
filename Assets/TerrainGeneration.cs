using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimplexNoise;

public class TerrainGeneration : MonoBehaviour
{
    private int yScale = 2;
    private int xScale = 10;
    private int step = 0;
    float noise(int x, float y) {
        return SimplexNoise.Noise.CalcPixel2D(x/xScale,0,1/(y/yScale))/255;
    }
    // Start is called before the first frame update
    void Start() {
        SimplexNoise.Noise.Seed = 0;
        for(int i = 1; i <= 500; i++) {
            
        }
    }

    // Update is called once per frame
    void Update() {
        if(step < 1000){
            for (int i = 1; i < 3; i++) {
                step++;
                float pm = 3+3*noise(step,900);
                float om = 35+35*noise(step,1000);
                float l2 = pm+pm*noise(step,20);
                float mh = 70+70*noise(step,40);
                float mmult = (1+noise(step,500))/2;
                float md = (7*noise(step,5))*Mathf.Pow(mmult,10f);
                float mm = (mh*(Mathf.Pow(mmult,17)))+md;
                float fd = pm+pm*noise(step,10);
                int height = Mathf.FloorToInt(fd+om+l2+mm);
                float tmult = (100+100*noise(step,300))/8;
                Instantiate(GameObject.Find("TerrainObject"),new Vector3(step,height+1,0),Quaternion.identity);
                for(int i2 = height; i2 >= 0; i2-=1) {
                    Instantiate(GameObject.Find("TerrainObject"),new Vector3(step,i2,0),Quaternion.identity);  
                }
            }
        }
    }
}
