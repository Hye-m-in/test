using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassportController : MonoBehaviour
{
    Image passport;

    // Start is called before the first frame update
    void Start()
    {
        passport = GetComponent<Image>();
        passport.alphaHitTestMinimumThreshold = 0.1f; //�������� �κи� Ŭ�� �ν�
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
