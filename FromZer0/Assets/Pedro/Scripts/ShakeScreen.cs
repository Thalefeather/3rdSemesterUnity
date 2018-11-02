using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour {

    public Animator camAnim;

    public void CamShake()
    {
        camAnim.SetTrigger("ScreenShake");
    }
}
