using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory{
    public static class inv{
        private static Color[] ids = {
            new Color(85/255f,142/255f,65/255f,1), // Grass
            new Color(106/255f,72/255f,53/255f), // Dirt
        };
        private static bool cn(float x,float y){
            return (Mathf.FloorToInt(x*100) == Mathf.FloorToInt(y*100));
        }
        public static string[] content = {"0,0","0,0","0,0","0,0","0,0","0,0","0,0","0,0","0,0","0,0"};
        public static int current = 1;
        public static void add(int id){
            if (id > 0){
                int i = -1;
                foreach(string s in content){
                    i++;
                    string[] ic = s.Split(',');
                    int cid = int.Parse(ic[0]);
                    int cct = int.Parse(ic[1]);
                    if(cid == id){
                        if (cid == 0){
                            cid = id;
                        }
                        content[i] = cid+","+(cct+1);
                        return;
                    }
                }
                string[] ic2 = content[current-1].Split(',');
                int cid2 = int.Parse(ic2[0]);
                int cct2 = int.Parse(ic2[1]);
                if(cid2 == id || cid2 == 0){
                    content[current-1] = id+",1";
                    return;
                }
            }
        }
        public static int getID(Color color){
            int i = 0;
            foreach(Color c in ids){
                i++;
                if (cn(c.r,color.r) && cn(c.g,color.g) && cn(c.b,color.b)){
                    return i;
                }
            }
            return 0;
        }
        public static Color getColor(int id){
            return ids[id-1];
        }
        public static void remove(int id){

        }
    }
}