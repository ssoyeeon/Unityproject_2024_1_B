using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExSoundPlay : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))    //1번을 누르면
        {
            SoundManager.instance.PlaySound("BackGround");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SoundManager.instance.PlaySound("Cannon");
        }
    }
}
