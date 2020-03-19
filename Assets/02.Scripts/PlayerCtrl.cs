using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [System.Serializable]
    public class PlayerAnim
    {
        public AnimationClip idle;
        public AnimationClip runF;
        public AnimationClip runB;
        public AnimationClip runL;
        public AnimationClip runR;
    }

    private float h = 0.0f;
    private float v = 0.0f;
    private float r = 0.0f;

    // Start is called before the first frame update

    private Transform tr;

    public float moveSpeed = 10.0f;

    public float rotSpeed = 80.0f;

    //인스펙터 뷰에 표시할 애니메이션 변수
    public PlayerAnim playerAnim;
    //Animation 컴포넌트를 저장하기 위한 변수
    [HideInInspector]
    public Animation anim;


    void Start()
    {
        tr = GetComponent<Transform>();

        //Animation 컴포넌트를 변수에 할당
        anim = GetComponent<Animation>();

        anim.clip = playerAnim.idle;
        anim.Play();

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        Debug.Log("h =" + h.ToString());
        Debug.Log("v =" + v.ToString());

        //전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);

        if (v >= 0.1f)
        {
            anim.CrossFade(playerAnim.runF.name, 0.3f); //전진 애니메이션
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade(playerAnim.runB.name, 0.3f); //후진 애니메이션
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade(playerAnim.runR.name, 0.3f); // 오른쪽 이동 애니메이션
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade(playerAnim.runL.name, 0.3f); // 왼쪽 이동 애니메이션
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);  // 정지 시 Idle 애니메이션
        }
    }
}
