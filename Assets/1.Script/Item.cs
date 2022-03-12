using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private State state;
    MeshRenderer renderer;
    public State _State { get { return state; } set { state = value; } }
    public void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.material = Instantiate(renderer.material);
        switch (state)
        {
            case State.first :
                renderer.material.color = Color.red;
                break;
            case State.second:
                renderer.material.color = Color.blue;
                break;
            case State.third:
                renderer.material.color = Color.green;
                break;
        }
    }
    public void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
}