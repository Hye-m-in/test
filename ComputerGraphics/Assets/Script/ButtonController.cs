using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    Image button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Image>();
        button.alphaHitTestMinimumThreshold = 0.1f; //�������� �κи� Ŭ�� �ν�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
