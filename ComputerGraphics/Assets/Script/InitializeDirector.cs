using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll(); //playerPrefs ��� ����
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
