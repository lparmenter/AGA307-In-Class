using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerPad : MonoBehaviour
{
    public GameObject triggeredObject;

    private void OnTriggerEnter(Collider other)
    {
        //Change the colour of the triggered object
        triggeredObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

    private void OnTriggerStay(Collider other)
    {
        //Increase the size of the triggered object by 0.01f
        triggeredObject.transform.localPosition = Vector3.one * 0.01f;
    }

    private void OnTriggerExit(Collider other)
    {
        //reset the size of the triggered object
        triggeredObject.transform.localScale = Vector3.one;
        //revert the colour of the triggered object
        triggeredObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
   
