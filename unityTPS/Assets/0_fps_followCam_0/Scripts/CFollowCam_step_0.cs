using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//3인칭 시점에 보다 유연한 카메라워크를 만들어보자.

public class CFollowCam_step_0 : MonoBehaviour
{
    [SerializeField] float mDistance = 0f;//후방거리
    [SerializeField] float mHeight = 0f;//상방거리
    [SerializeField] GameObject mLookAtObj = null;//카메라가 바라볼 게임오브젝트
    [SerializeField] float mDampingTrace = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //모든 렌더링 결과를 만들고 나서 카메라 위치 조정을 하기 위해 Late Update에 구현
    private void LateUpdate()
    {
        Vector3 tOffset = Vector3.zero;
        tOffset = -1f * mLookAtObj.transform.forward * mDistance + Vector3.up * mHeight;
        //이동 벡터 구함

        Vector3 tPosition = Vector3.zero;
        tPosition = mLookAtObj.transform.position + tOffset;
        //카메라의 위치 구함

        //카메라의 현재 위치 설정
        //this.transform.position = tPosition;
        this.transform.position = Vector3.Lerp(this.transform.position, tPosition, mDampingTrace);
        //Lerp(시작점, 끝점, 둘사이의 어딘가 중간값(가중치))
        //Lerp : Linear Interplation 선형 보간, 일차 함수를 사용하여 근사치를 구한다.
        //선형 Linear : 직선의 방정식, 일차 함수
        //보간 Interplation : 근사치를 구한다.

     /*
      감쇠되는 원리
       
        mDampingTrace를 0.5라고 가정

        Cur             New
        ===================
        0                1
                0.5
        ===================
                 0       1
        ===================
                     0   1
        ===================
                       0 1
        ===================
                        ...
     */

        //카메라가 바라보는 지정 설정(즉, 카메라의 회전)
        this.transform.LookAt(mLookAtObj.transform.position);
    }
}
