using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCam_step_1 : MonoBehaviour
{
    [SerializeField] GameObject mLookAtObj = null;//ī�޶� �ٶ󺸴� ���ӿ�����Ʈ

    [SerializeField] float mArmLength = 0f;//ĳ���ͷκ��� ī�޶� ������ �Ÿ�(����)

    //���콺�� 2D ��ǥ���� ����
    float mMouseXVal = 0f;//���콺 x�Է°�(Y���� ȸ�������� �¿� ȸ��)
    float mMouseYVal = 0f;//���콺 y�Է°�(X���� ȸ�������� ���� ȸ��)

    [SerializeField] Vector3 mOffset = Vector3.zero;
    //ĳ���ͷκ��� �󸶳� �������ִ����� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        mOffset = new Vector3(0f, 0f, -1f * mArmLength);
        //mMouseYVal = 45f;
        mMouseYVal = this.transform.rotation.eulerAngles.x;//<-- ���Ϸ� ��, x���� ȸ�������� �� ����

        //1degree : ���� ���� 360���� ����ؼ� �ϳ��� ���Ѱ��� 1��
        //1radian : ������ ������������ ȣ�� ���̸� �����̶�� ��

        //������ ȸ������ �ϳ� �����ص�
        this.transform.rotation = Quaternion.Euler(mMouseYVal, mMouseXVal, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float tMouseX = Input.GetAxis("Mouse X");
        float tMouseY = Input.GetAxis("Mouse Y");

        mMouseXVal = mMouseXVal + tMouseX;
        if (mMouseXVal > 60f)
        {
            mMouseXVal = 60f;
        }
        else if (mMouseXVal < -60f)
        {
            mMouseXVal = -60f;
        }
        mMouseYVal = mMouseYVal + tMouseY * (-1.0f);
        //Screen������ ������ ��ǥ��(2D)�� ����Ѵ�.
        //���⼭�� y�� ������ �������� �����Ƿ� -1�� ���Ͽ� �����Ѵ�.

        //'���Ϸ� ���� ���� ȸ���� ����'�ϰ� �̰��� '������� ��ȯ'�Ͽ� ����
        this.transform.rotation = Quaternion.Euler(mMouseYVal, mMouseXVal, 0f);
    }

    private void LateUpdate()
    {
        //���ͳ����� ��������
        //��ġ = ��ġ + ����
        //this.transform.position = mLookAtObj.transform.position + mOffset;

        //��ġ = ��ġ + ����� + ����
        //<---- ����� + ���ʹ� ����Ƽ���� �����Ǿ� �ִ�.
        this.transform.position = mLookAtObj.transform.position + this.transform.rotation * mOffset;


    }
}
