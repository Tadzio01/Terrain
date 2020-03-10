using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory{
    public static class inv{
        private static Color[] ids = {
            new Color(85/255,142/255,65/255),
        };
        public static string[] content = {"0,0","0,0","0,0","0,0","0,0","0,0","0,0","0,0","0,0","0,0"};
        public static void add(int id){
            int i = -1;
            foreach(string s in content){
                i++;
                string[] ic = s.Split(',');
                int cid = int.Parse(ic[0]);
                int cct = int.Parse(ic[1]);
                if(cid == 0 || cid == id){
                    if (cid == 0){
                        cid = id;
                    }
                    content[i] = cid+","+cct+1;
                }
            }
        }
        public static int getID(Color color){
            int i = 0;
            foreach(Color c in ids){
                i++;
                if (color == c){
                    return i;
                }
            }
            return 0;
        }
        public static Color getColor(int id){
            return ids[id];
        }
        public static void remove(int id){

        }
    }
}