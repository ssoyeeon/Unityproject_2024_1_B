using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;      //DoTween�� ����ϱ� ����

public class TweenTest : MonoBehaviour
{
    Tween tween;                                    //Ʈ�� ����
    Sequence sequence;                              //������ ����
    // Start is called before the first frame update
    void Start()
    {
        //tween = transform.DOMoveX(5, 0f);                                  //Tween�� ���ؼ� ������Ʈ�� X������ 2�ʵ��� 5��ŭ ����.
        //transform.DORotate(new Vector3(0, 0, 180), 0.3f);         //Tween�� ���ؼ� ������Ʈ�� Z������ 0.3�ʵ��� 180�� ��ŭ ȸ���Ѵ�.
        //transform.DOScale(new Vector3(2, 2, 2), 2);              //Tween�� ���ؼ� ������Ʈ�� 2�ʵ��� 2��� Ŀ����.

        //Sequence sequnence = DOTween.Sequence();               //�������� �����Ѵ�. ���� Tween�� ������ ���� Ʈ���� ���۵ȴ�.
        //sequnence.Append(transform.DOMoveX(5, 0.5f));
        //sequnence.Append(transform.DORotate(new Vector3(0, 0, 180), 0.3f));
        //sequnence.Append(transform.DOScale(new Vector3(2, 2, 2), 2));

        //transform.DOMoveX(5, 2f).SetEase(Ease.OutBounce).OnComplete(DeactivateObject);                  //�̵��Ҷ� ȿ���� �߰� ��ų �� �ִ�.(Ease.OutBounce)
        //transform.DOShakeRotation(2f, new Vector3(0,0,5), 10, 90);        //�̵��ϴ� ���� ȸ�� ��� ȿ��

        sequence = DOTween.Sequence();        //������ ����
        sequence.Append(transform.DOMoveX(5, 0.7f));     //������ �߰�
        sequence.SetLoops(-1, LoopType.Yoyo);          //������ ������ ���� �ɼǵ� ����

    }
    void DeactivateObject()                     //������ ����� ���Ŀ� �Լ��� ȣ��
    {
        gameObject.SetActive(false);            //������Ʈ�� ����
        Debug.Log("���� ����");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        //�����̽��ٸ� ������
        {
            sequence.Kill();                        //�ش� �������� ���δ�!!!!!!!!!!!!!!!!!!
            //tween.Kill();                         //�ش� Ʈ���� ���δ�!!!!!!!!!!!!!!!!!
        }
    }
}
