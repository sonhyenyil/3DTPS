using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPChar_step_1 : MonoBehaviour
{
    //캐릭터의 움직임(이동)을 담당하는 컴포넌트는 이것을 항상 사용할 것이라고 가정
    //<-- 그래서 유니티 에디터에서 참조하도록 하겠다 라고 결정
    [SerializeField] CharacterController mCharController = null;
    //CharacterController는 ridgidbody 물리가 적용되지 않는경우 사용한다.

    [SerializeField] float mSpeed = 0f; //속력

    [SerializeField] Vector3 mVelocity = Vector3.zero; //속도

    [SerializeField] float GRAVITY = -9.8f; //중력가속도 y성분, 스칼라

    [SerializeField] float mJumpPower = 0f; //점프 힘의 크기(속도의 y성분에 대응되는 스칼라)

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //지표면에 닿아있다면
        if (mCharController.isGrounded)
        {
            //축입력
            float tV = Input.GetAxis("Vertical");//[-1, +1]
            float tH = Input.GetAxis("Horizontal");

            //zx 평면에서의 속도 결정
            Vector3 tVelocity = new Vector3(tH, 0f, tV);

            //입력값을 기반으로, zx평면에서의 속도 결정
            mVelocity = tVelocity.normalized * mSpeed;//임의의 속도 지정
        }
        else//지표면에 닿아있지 않다면 (즉, 공중이라면)
        {
            //현재 속도 = 이전 속도 + 가속 속도 * 시간간격
            //현재 위치 = 이전 위치 + 속도 * 시간간격 //현재 위치의 속도는 현재 속도

            mVelocity.y = mVelocity.y + GRAVITY * Time.deltaTime;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        { 
            mVelocity.y = mJumpPower;
        }

        //CharacterController에서 제공하는 Move함수를 이용한다.
        //<-- 오일러 수치해석 방법에 의해 작동하는 함수이다.
        mCharController.Move(mVelocity * Time.deltaTime);//<--시간기반 진행
    }
}
