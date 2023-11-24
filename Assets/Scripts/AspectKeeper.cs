// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class AspectKeeper : MonoBehaviour
{
    [SerializeField] 
    private Camera targetCamera;   // �ΏۃJ����
    [SerializeField] 
    private Vector2 aspectVec;     // �ړI�𑜓x

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var screenAspect = Screen.width / (float)Screen.height; // ��ʂ̃A�X�y�N�g��
        var targetAspect = aspectVec.x / aspectVec.y;           // �ړI�̃A�X�y�N�g��
        var magRate = targetAspect / screenAspect;              // �{��
        var viewportRect = new Rect(0, 0, 1, 1);                // viewport�����l��Rect���쐬

        if (magRate < 1)
        {
            viewportRect.width = magRate;                       // �����̕ύX
            viewportRect.x = 0.5f - viewportRect.width * 0.5f;  // ������
        }
        else
        {
            viewportRect.height = 1 / magRate;                  // �c���̕ύX
            viewportRect.y = 0.5f - viewportRect.height * 0.5f; // ������
        }

        targetCamera.rect = viewportRect;   // �J������viewport�ɓK�p
    }
}
