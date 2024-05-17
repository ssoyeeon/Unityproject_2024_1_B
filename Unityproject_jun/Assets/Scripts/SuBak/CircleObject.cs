using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;                      //드래그 중인지 판단
    public bool isUsed;                      //사용 완료 판단하는 (bool)
    Rigidbody2D rigidbody2D;                //2D 강체를 불러온다.

    public int index;                //과일 번호를 만든다.

    void Awake()                                         //시작하기 전 사용
    {
        isUsed = false;                                  //사용 완료가 되지 않음(처음 사용)
        rigidbody2D = GetComponent<Rigidbody2D>();      //강체를 가져온다.
        rigidbody2D.simulated = false;                  //생성될때는 시뮬레이팅 되지 않는다.
    }
    void Start()
    {

    }

    void Update()
    {
        if (isUsed) return;                              //사용 완료된 물체를 어디상 업데이트 하기 않기 위해서 return으로 돌려 준다.

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     //화면에서 -> 월드 포지션 위치 찾아주는 함수 사용
            float leftBorder = -4f + transform.localScale.x / 2f;                  //최대 왼쪽으로 갈 수 있는 범위
            float rightBorder = 4f - transform.localScale.x / 2f;                  //최대 오른쪽으로 갈 수 있는 범위

            if(mousePos.x < leftBorder) mousePos.x = leftBorder;   //최대 왼쪽으로 갈 수 있는 범위를 넘어갈 경우 최대 범위 위치를 대입해서 넘어가지 못하게 한다.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;
            mousePos.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f); //이 오브젝트의 위치는 마우스 위치로 이동한다. 0.2f 속도로 이동 
        }


        if (Input.GetMouseButtonDown(0)) Drag();       //마우스 버튼이 눌렸을 때 Drag 함수 호출
        if (Input.GetMouseButtonUp(0)) Drop();         //마우스 버튼이 올라갈 때 Drop 함수 호출
        

    }

    void Drag()
    {
        isDrag = true;                   //드래그 시작 (true)
        rigidbody2D.simulated = false;  //드래그 중에는 물리 현상이 일어나는것을 막기 위해서 (false)
    }

    void Drop()
    {
        isDrag = false;                  //드래그가 종료
        isUsed = true;                   //사용이 완료
        rigidbody2D.simulated = true;    //물리 현상 시작

        GameObject Temp = GameObject.FindWithTag("GameManager");        //Tag : GameManager를 Scene 찾아서 오브젝트 가져옴
        if(Temp != null )                                               //해당 오브젝트가 존재하면
        {
            Temp.gameObject.GetComponent<GameManager>().GenObject();    //GenObject 함수를 호출 (GetComponent 통해 클래스 접근)
        }
    }

    public void Used()
    {
        isDrag=false;
        isUsed=true;
        rigidbody2D.simulated = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)   //2D 충돌이 일어날 경우
    {
        if (index >= 7)         //준비된 과일이 최대 7개
            return;
            
        if(collision.gameObject.tag == "Fruit")     //충돌 물체의 태그가 Fruit 일 경우
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();  //임시로  Class temp를 선언하고 충돌체의 Class(circleObject)를 받아온다.

            if (temp.index == index)
            {
                if (gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())  //유니티에서 지원하는 고유의 ID를 받아와서 ID가 큰쪽에서 다음 과일 생성
                {

                    GameObject Temp = GameObject.FindWithTag("GameManager");
                    if (Temp != null)
                    {
                        Temp.gameObject.GetComponent<GameManager>().MergeObject(index, gameObject.transform.position);
                    }
                    Destroy(temp.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
