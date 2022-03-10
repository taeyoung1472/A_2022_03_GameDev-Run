using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingBase : MonoBehaviour
{
    [Header("Pooling ฐüทร")]
    [SerializeField] private bool isTimePolling;
    [SerializeField] private float pollingTime;
    [SerializeField] private PoolType poolType;
    public void Set()
    {
        gameObject.SetActive(true);
        transform.parent = GameManager.Instance.PoolingManager.Holder;
        if (isTimePolling)
        {
            StartCoroutine(Pooling());
        }
    }
    IEnumerator Pooling()
    {
        yield return new WaitForSeconds(pollingTime);
        Pool();
    }
    public void Pool()
    {
        gameObject.SetActive(false);
        transform.parent = GameManager.Instance.PoolingManager.GetTrans(poolType);
    }
}