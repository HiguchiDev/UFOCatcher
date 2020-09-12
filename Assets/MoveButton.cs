using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    bool isActive = false;
    float TRANSPARENCY_MAX = 0.8f;
    float TRANSPARENCY_MIN = 0.2f;
    float TRANSPARENCY_SPEED = 0.025f;

    int mode = 1;   //0 : 透明度上昇, 1 : 透明度下降
    int DOWN = 1, UP = 0;

    float AC_R = 1.0f, AC_G = 0.85f, AC_B = 0.1f;
    float INI_R = 0.5f, INI_G = 0.5f, INI_B = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isActive){
            float a = GetComponent<Renderer>().material.color.a;

            
            if(mode == DOWN){
                a -= TRANSPARENCY_SPEED;
                GetComponent<Renderer>().material.color = new Color(AC_R, AC_G, AC_B, a);

                if(a <= TRANSPARENCY_MIN){            
                    mode = UP;
                }
            }
            else{
                a += TRANSPARENCY_SPEED;
                GetComponent<Renderer>().material.color = new Color(AC_R, AC_G, AC_B, a);

                if(a >= TRANSPARENCY_MAX){            
                    mode = DOWN;
                }
            }

        }
        else{
            GetComponent<Renderer>().material.color = new Color(INI_R, INI_G, INI_B, TRANSPARENCY_MAX);
        }
    }

    public void active(){
        isActive = true;
        GetComponent<Renderer>().material.color = new Color(AC_R, AC_G, AC_B, TRANSPARENCY_MIN);
    }

    public void inactive(){
        isActive = false;
    }
}
