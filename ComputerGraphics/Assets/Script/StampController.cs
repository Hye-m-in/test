using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampController : MonoBehaviour
{
    public GameObject Paris;
    public GameObject Japan;
    public GameObject USA;
    public GameObject ARG;

    // Start is called before the first frame update
    void Start()
    {
        //Paris ���� ���� �� �ĸ� ���� Ȱ��ȭ
        if(PlayerPrefs.GetInt("Parissuccess", 0) == 1)
        {
            Paris.SetActive(true);
        }
        else
        {
            Paris.SetActive(false);
        }

        //Japan ���� ���� �� �Ϻ� ���� Ȱ��ȭ
        if (PlayerPrefs.GetInt("Japansuccess", 0) == 1)
        {
            Japan.SetActive(true);
        }
        else
        {
            Japan.SetActive(false);
        }

        //USA ���� ���� �� �̱� ���� Ȱ��ȭ
        if (PlayerPrefs.GetInt("USAsuccess", 0) == 1)
        {
            USA.SetActive(true);
        }
        else
        {
            USA.SetActive(false);
        }

        //ARG ���� ���� �� �Ƹ���Ƽ�� ���� Ȱ��ȭ
        if (PlayerPrefs.GetInt("ARGsuccess", 0) == 1)
        {
            ARG.SetActive(true);
        }
        else
        {
            ARG.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
