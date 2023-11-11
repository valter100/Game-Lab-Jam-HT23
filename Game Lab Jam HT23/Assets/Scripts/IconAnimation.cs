using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconAnimation : MonoBehaviour
{
    [SerializeField] float tick = 0.1f;
    Quaternion moveShipRot = new Quaternion(0, 0, -0.1f, 1);
    Quaternion moveShipZero = new Quaternion(0, 0, 0.1f, 1);
    [SerializeField] RectTransform rectTransform;
    bool switchRot = false;
    private void Start()
    {
        InvokeRepeating("DoSomething", 0f, tick);
    }
    private void DoSomething()
    {
        if (switchRot)
        {
            rectTransform.rotation = moveShipZero;
            //Debug.Log("z = 0");
            switchRot = false;
        }
        else
        {
            switchRot = true;
            rectTransform.rotation = moveShipRot;
            //Debug.Log("z != 0");
        }
    }
}
