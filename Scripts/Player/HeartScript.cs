using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{

    public Sprite fullHeart, halfHeart, emptyHeart;
    Image heartIMG;

    private void Awake()
    {
        heartIMG = GetComponent<Image>();
    }

    public void SetHeartIMG(HeartStatus status)
    {
        switch(status)
        {
            case HeartStatus.Empty:
                heartIMG.sprite = emptyHeart;
                break;
            case HeartStatus.Half:
                heartIMG.sprite = halfHeart;
                break;
            case HeartStatus.Full:
                heartIMG.sprite = fullHeart;
                break;
        }
    }

}

public enum HeartStatus
{
    Empty = 0,
    Half = 1,
    Full = 2
}
