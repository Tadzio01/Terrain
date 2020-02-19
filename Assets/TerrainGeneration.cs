using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimplexNoise;

public class TerrainGeneration : MonoBehaviour
{
    float noise(int x, float y) {
        return SimplexNoise.Noise.CalcPixel1D(x,1/y);
    }
    string stringrep(string s, int y) {
        string rs = "";
        for(int i = 1; i <= y; i++) {
            rs = rs + s;
        }
        return rs;
    }
    // Start is called before the first frame update
    void Start() {
        SimplexNoise.Noise.Seed = 0;
        for(int i = 1; i <= 50; i++) {
            float pm = 3+3*noise(i,900);
            float om = 35+35*noise(i,1000);
            float l2 = pm+pm*noise(i,20);
            float mh = 70+70*noise(i,40);
            float mmult = (1+noise(i,500))/2;
            float md = Mathf.Pow((7*noise(i,5))*mmult,10f);
            float mm = (mh*(Mathf.Pow(mmult,17)))+md;
            float fd = pm+pm*noise(i,10);
            int height = Mathf.FloorToInt(fd+om+l2+mm);
            float tmult = (100+100*noise(i,300))/8;
            string s = new String("#",height);
            Debug.Log(s);

            //Instantiate(GameObject.Find("TerrainObject"),new Vector3(i,height+1,0),Quaternion.identity);
            //for(int i2 = height; i2 >= 0; i2-=1) {
             // Instantiate(GameObject.Find("TerrainObject"),new Vector3(i,i2,0),Quaternion.identity);  
           // }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
