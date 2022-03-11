using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectAnim : MonoBehaviour
{
    [SerializeField] private bool isLeft;
    RectTransform rect;
    float localPos;
    float pos;
    bool isActive;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        localPos = rect.transform.position.x;
        pos = localPos;
    }
    void Update()
    {
        pos = Mathf.Lerp(pos,isActive ? localPos + (isLeft ? -3000 : 3000) : localPos,Time.deltaTime);
        rect.transform.position = new Vector2(pos, rect.transform.position.y);
    }
    public void SetAnim(bool value)
    {
        isActive = true;
    }
}