using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyBox : MonoBehaviour
{

    public Material matl;

    public void ChangeSky()
    {

        RenderSettings.skybox = matl;
    }
}
