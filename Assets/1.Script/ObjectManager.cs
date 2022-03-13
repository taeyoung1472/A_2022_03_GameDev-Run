using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public void SetActiveTrue(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void SetActiveFalse(GameObject obj)
    {
        obj.SetActive(false);
    }
}