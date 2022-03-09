using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private Vector2 posLimit;
    [SerializeField] private float senserVity;
    [SerializeField] SkinnedMeshRenderer renderer;
    State state = State.first;
    float pos;
    public void Start()
    {
        renderer.material = Instantiate(renderer.material);
        switch (state)
        {
            case State.first:
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
    public void Controll(float value)
    {
        value *= senserVity;
        pos += value;
        pos = Mathf.Clamp(pos,posLimit.x,posLimit.y);
        transform.position = new Vector3(pos, transform.position.y, transform.position.z);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Item>()._State == state)
        {
            Destroy(other.gameObject);
            GameManager.Instance.ComboSystem.ComboUpdate();
        }
        else
        {
            GameManager.Instance.ComboSystem.ComboReset();
        }
    }
}
public enum State
{
    first,
    second,
    third
}