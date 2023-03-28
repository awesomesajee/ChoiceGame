using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{

    //add null checks
    public void SwitchBackground(Sprite image)
    {
        this.GetComponent<Image>().sprite = image;
    }
}
