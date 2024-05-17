using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] CircleObject;             //���� ������ ������Ʈ
    public Transform GenTransform;              //������ ������ ��ġ ������Ʈ
    public float TimeCheck;                     //�ð��� üũ�ϱ� ���� (float) ��
    public bool isGen;                          //���� �Ϸ� üũ (bool) ��


    // Start is called before the first frame update
    void Start()
    {
        GenObject();                    //������ ���۵Ǿ��� �� �Լ��� ȣ���Ͽ� �ʱ�ȭ ��Ų��.
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGen)
        {
            TimeCheck -= Time.deltaTime;                              //�� �����Ӹ��� ������ �ð��� ���ش�.
            if(TimeCheck <= 0)                                      //�ش� �� �ð��� ������ ��� (1�� -> 0�ʰ� �Ǿ��� ���)
            {
                int RandNumber = Random.Range(0, 3);                //0 ~ 2 ������ ���� ���ڸ� ����
                GameObject Temp = Instantiate(CircleObject[RandNumber]);        //���� ������ ������Ʈ�� ���� �����ش�.(Instantiate)
                Temp.transform.position = GenTransform.position;    //������ ��ġ�� �̵� ��Ų��.
                isGen = true;                                       //Gen�� �Ǿ��ٰ� true�� bool���� �����Ѵ�.
            }
        }
    }

    public void GenObject()
    {
        isGen = false;              //�ʱ�ȭ : isGen�� false (���� ���� �ʾҴ�)
        TimeCheck = 1.0f;           //1�� �� ���� �������� ���� ��Ű�� ���� �ʱ�ȭ
    }

    public void MergeObject(int index, Vector3 position)    //Merge �Լ��� ���Ϲ�ȣ(int) �� ���� ��ġ��(Vector3)�� ���� �޴´�.
    {
        GameObject Temp = Instantiate (CircleObject [index] );        //index�� �״�� ����. ( 0���� �迭�� ���۵����� index���� 1 �� �־)
        Temp.transform.position = position;
        Temp.GetComponent<CircleObject>().Used();
    }
}