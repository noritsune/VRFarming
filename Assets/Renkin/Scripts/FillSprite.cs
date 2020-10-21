using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillSprite : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private RectTransform _targetRect;

    void Start()
    {
        FillScreen();
    }

    void FillScreen()
    {
        // カメラの外枠のスケールをワールド座標系で取得
        float worldScreenHeight=_targetRect.sizeDelta.y;
        float worldScreenWidth=_targetRect.sizeDelta.x;

        // スプライトのスケールもワールド座標系で取得
        float width  = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        //  両者の比率を出してスプライトのローカル座標系に反映
        transform.localScale = new Vector3 (worldScreenWidth / width, worldScreenHeight / height);

        // カメラの中心とスプライトの中心を合わせる
        Vector3 camPos = _targetRect.position;
        camPos.z = 0;
        transform.position = camPos;
    }
}
