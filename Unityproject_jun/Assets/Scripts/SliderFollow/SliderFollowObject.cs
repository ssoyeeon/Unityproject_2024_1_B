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
        {   //3D ������Ʈ�� ��ġ�� ȭ�� ��ǥ�� ��ȯ
            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetObject.position + offset);
            //ȭ�� ��ǥ�� Canvas ��ǥ�� ��ȯ
            RectTransform canvasRect = slider.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            Vector2 cavasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out cavasPos);
            //Slider UI ��ġ�� ������Ʈ
            slider.transform.localPosition = cavasPos;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D ������!");
            rig.AddForce(Vector3.right * Force, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A ������!");
            rig.AddForce(Vector3.left * Force, ForceMode.VelocityChange);
        }

    }
}
