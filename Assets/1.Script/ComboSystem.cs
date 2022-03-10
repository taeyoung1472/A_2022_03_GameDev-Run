using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    [SerializeField] private AudioClip comboSoundClip, comboCancelClip;
    int combo;
    public void ComboUpdate()
    {
        combo++;
        GameManager.Instance.PoolingManager.PoolObject(PoolType.Sound).GetComponent<SoundObject>().Sound(comboSoundClip, 1, 1 + combo * 0.1f);
        print($"Combo : {combo}!");
    }
    public void ComboReset()
    {
        combo = 0;
        GameManager.Instance.PoolingManager.PoolObject(PoolType.Sound).GetComponent<SoundObject>().Sound(comboCancelClip);
        print($"Combo : End!");
    }
    public int ComboGet()
    {
        return combo;
    }
}