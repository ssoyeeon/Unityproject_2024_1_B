using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class SliderFollowObject : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset;
    public Slider slider;
    public GameObject target;

    public Rigidbody rig;
    public int Force = 5;

    // Update is called once per frame
    void Update()
    {
        if(targetObject != null && slider != null)
        {   //3D 오브젝트의 위치를 화면 좌표로 변환
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.position + offset);
            //화면 좌표를 Canvas 좌표로 변환
            RectTransform canvasRect = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 cavasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out cavasPos);
            //Slider UI 위치를 업데이트
            slider.transform.localPosition = cavasPos;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D 눌렀졍!");
            rig.AddForce(Vector3.right * Force, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A 눌렀졍!");
            rig.AddForce(Vector3.left * Force, ForceMode.VelocityChange);
        }

    }
}
