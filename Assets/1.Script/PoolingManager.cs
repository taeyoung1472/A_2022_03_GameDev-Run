using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [SerializeField] private Transform holder;
    [SerializeField] private Transform[] objectCategory;
    [SerializeField] private GameObject[] objectPrefabs;
    public Transform Holder { get { return holder; } }
    public GameObject PoolObject(PoolType _type)
    {
        if (objectCategory[(int)_type].childCount > 0)
        {
            GameObject obj = objectCategory[(int)_type].GetChild(0).gameObject;
            obj.GetComponent<PoolingBase>().Set();
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(objectPrefabs[(int)_type], holder);
            obj.GetComponent<PoolingBase>().Set();
            return obj;
        }
    }
    public Transform GetTrans(PoolType _type)
    {
        return objectCategory[(int)_type];
    }
    [ContextMenu("¿Ã∏ßª¿‘")]
    public void SetName()
    {
        holder.name = "Holder";
        for (int i = 0; i < objectCategory.Length; i++)
        {
            objectCategory[i].name = "Catergory " + i;
        }
    }
}
public enum PoolType
{
    Sound
}