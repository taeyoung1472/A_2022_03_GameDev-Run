using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlatFormSpawn : MonoBehaviour
{
    [SerializeField] private Transform platFormCarry;
    [SerializeField] GameObject lastPlatForm;
    [SerializeField] PlatFromSystem ps;
    float lengthTotal = 0;
    void Start()
    {
        FirstSpawn();
    }
    void FirstSpawn()
    {

        GameObject obj1 = Instantiate(ps.Get(true), platFormCarry);
        obj1.transform.position = new Vector3(0, 0, lengthTotal);
        lengthTotal += obj1.GetComponent<PlatForm>().Length * 2;
        while (lengthTotal < 30)
        {
            lastPlatForm = Instantiate(ps.Get(), platFormCarry);
            lastPlatForm.transform.position = new Vector3(0, 0, lengthTotal);
            lengthTotal += lastPlatForm.GetComponent<PlatForm>().Length * 2;
        }
        lengthTotal -= lastPlatForm.GetComponent<PlatForm>().Length * 2;
        StartCoroutine(SpawnPlatForm());
    }
    IEnumerator SpawnPlatForm()
    {
        float temp = lengthTotal;
        while (lengthTotal < 100)
        {
            yield return new WaitUntil(() => lastPlatForm.transform.position.z < temp);
            lastPlatForm = Instantiate(ps.Get(), platFormCarry);
            lastPlatForm.transform.position = new Vector3(0, 0, temp + lastPlatForm.GetComponent<PlatForm>().Length * 2);
            lengthTotal += lastPlatForm.GetComponent<PlatForm>().Length * 2;
        }
        print("��");
    }
}
[Serializable]
public class PlatFromSystem
{
    [SerializeField] private GameObject defaultPlatForm;
    [SerializeField] private GameObject[] jamPlatForm;
    [SerializeField] private GameObject[] colorChangePlatForm;
    PlatFormState ps;
    public GameObject Get(bool isDefault = false)
    {
        if (isDefault)
        {
            return defaultPlatForm;
        }
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                return defaultPlatForm;
                break;
            case 1:
                //if ()
                //{

               // }
                return jamPlatForm[UnityEngine.Random.Range(0,jamPlatForm.Length)];
                break;
            case 2:
                return colorChangePlatForm[UnityEngine.Random.Range(0, colorChangePlatForm.Length)];
                break;
            default:
                return null;
        }
    }
}
public enum PlatFormState
{
    _default,
    _jam,
    _change
}