using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatForm : MonoBehaviour
{
    [SerializeField] private float maxScore;
    [SerializeField] private float length;
    [SerializeField] private Transform[] itemTrans;
    public float Length { get { return length; } }
    public void Start()
    {
        State[] state = new State[3];
        switch (Random.Range(0,6))
        {
            case 0:
                state[0] = State.first; state[1] = State.second; state[2] = State.third;
                break;
            case 1:
                state[0] = State.first; state[2] = State.second; state[1] = State.third;
                break;
            case 2:
                state[1] = State.first; state[0] = State.second; state[2] = State.third;
                break;
            case 3:
                state[1] = State.first; state[2] = State.second; state[0] = State.third;
                break;
            case 4:
                state[2] = State.first; state[1] = State.second; state[0] = State.third;
                break;
            case 5:
                state[2] = State.first; state[0] = State.second; state[1] = State.third;
                break;
        }
        for (int i = 0; i < itemTrans.Length; i++)
        {
            for (int j = 0; j < itemTrans[i].childCount; j++)
            {
                itemTrans[i].GetChild(j).GetComponent<Item>()._State = state[i];
            }
        }
    }
    public void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 4f);
    }
}