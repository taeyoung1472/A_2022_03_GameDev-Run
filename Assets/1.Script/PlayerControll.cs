using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private Vector2 posLimit;
    [SerializeField] private State state;
    [SerializeField] private float senserVity;
    [SerializeField] SkinnedMeshRenderer renderer;
    [SerializeField] private Animator animator;
    Transform officeChair;
    bool isEnd;
    float pos;
    public void Start()
    {
        renderer.material = Instantiate(renderer.material);
        Set();
    }
    public void Update()
    {
        if (isEnd)
        {
            transform.position = Vector3.Lerp(transform.position, officeChair.position, Time.deltaTime);
            if (Vector3.Distance(transform.position, officeChair.position) < 1)
            {
                animator.SetBool("IsEnd", true);
                transform.position = officeChair.position;
            }
        }
    }
    public void Set(State _state = State.first)
    {
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
        if (!isEnd)
        {
            value *= senserVity;
            pos += value;
            pos = Mathf.Clamp(pos, posLimit.x, posLimit.y);
            transform.position = new Vector3(pos, transform.position.y, transform.position.z);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            print("End!");
            officeChair = other.transform;
            other.GetComponentInParent<PlatForm>().Stop();
            isEnd = true;
        }
        if(other.CompareTag("Item"))
        {
            if (other.GetComponent<Item>()._State == state)
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
}
public enum State
{
    first,
    second,
    third
}