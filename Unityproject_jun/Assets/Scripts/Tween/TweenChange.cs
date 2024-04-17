using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenChange : MonoBehaviour
{
    public bool isPunch = false;                //���������� �Է��� ������ ���� ���� ���� Flag ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPunch)           //��ġ üũ�� false �� ���
            {
                isPunch = true;         //��ġ üũ�� Ture ������༭ ��� �Է��� ������� ������ ���� ���� ���ϰ� ���´�.
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPuch);    //��Ī ȿ���� ���� ������ EndPuch �Լ� ȣ��
            }
        }
    }

    void EndPuch()
    {
        isPunch = false;
    }
}
