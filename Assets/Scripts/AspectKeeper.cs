// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class AspectKeeper : MonoBehaviour
{
    [SerializeField] 
    private Camera targetCamera;   // 対象カメラ
    [SerializeField] 
    private Vector2 aspectVec;     // 目的解像度

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var screenAspect = Screen.width / (float)Screen.height; // 画面のアスペクト比
        var targetAspect = aspectVec.x / aspectVec.y;           // 目的のアスペクト比
        var magRate = targetAspect / screenAspect;              // 倍率
        var viewportRect = new Rect(0, 0, 1, 1);                // viewport初期値でRectを作成

        if (magRate < 1)
        {
            viewportRect.width = magRate;                       // 横幅の変更
            viewportRect.x = 0.5f - viewportRect.width * 0.5f;  // 中央寄せ
        }
        else
        {
            viewportRect.height = 1 / magRate;                  // 縦幅の変更
            viewportRect.y = 0.5f - viewportRect.height * 0.5f; // 中央寄せ
        }

        targetCamera.rect = viewportRect;   // カメラをviewportに適用
    }
}
