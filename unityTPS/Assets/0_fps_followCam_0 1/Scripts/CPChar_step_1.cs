using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPChar_step_1 : MonoBehaviour
{
    //ĳ������ ������(�̵�)�� ����ϴ� ������Ʈ�� �̰��� �׻� ����� ���̶�� ����
    //<-- �׷��� ����Ƽ �����Ϳ��� �����ϵ��� �ϰڴ� ��� ����
    [SerializeField] CharacterController mCharController = null;
    //CharacterController�� ridgidbody ������ ������� �ʴ°�� ����Ѵ�.

    [SerializeField] float mSpeed = 0f; //�ӷ�

    [SerializeField] Vector3 mVelocity = Vector3.zero; //�ӵ�

    [SerializeField] float GRAVITY = -9.8f; //�߷°��ӵ� y����, ��Į��

    [SerializeField] float mJumpPower = 0f; //���� ���� ũ��(�ӵ��� y���п� �����Ǵ� ��Į��)

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //��ǥ�鿡 ����ִٸ�
        if (mCharController.isGrounded)
        {
            //���Է�
            float tV = Input.GetAxis("Vertical");//[-1, +1]
            float tH = Input.GetAxis("Horizontal");

            //������ �����غ��� Move�� ������ǥ�� �������� �۵��Ѵ�.
            //�׷��Ƿ� ���ΰ�ĳ���� �����̶�� ǥ���� �ʿ��ϴ�.
            //zx ��鿡���� �ӵ� ����
            Vector3 tVelocity = new Vector3(tH, 0f, tV); //local��ǥ�� �󿡼� ���� ����
            tVelocity = mCharController.transform.TransformDirection(tVelocity); //local -> World ��ȯ�� ����

            //�Է°��� �������, zx��鿡���� �ӵ� ����
            mVelocity = tVelocity.normalized * mSpeed;//������ �ӵ� ����
        }
        else//��ǥ�鿡 ������� �ʴٸ� (��, �����̶��)
        {
            //���� �ӵ� = ���� �ӵ� + ���� �ӵ� * �ð�����
            //���� ��ġ = ���� ��ġ + �ӵ� * �ð����� //���� ��ġ�� �ӵ��� ���� �ӵ�

            mVelocity.y = mVelocity.y + GRAVITY * Time.deltaTime;

        }

        if (Input.GetKeyUp(KeyCode.Space))
        { 
            mVelocity.y = mJumpPower;
        }

        //CharacterController���� �����ϴ� Move�Լ��� �̿��Ѵ�.
        //<-- ���Ϸ� ��ġ�ؼ� ����� ���� �۵��ϴ� �Լ��̴�.
        mCharController.Move(mVelocity * Time.deltaTime);//<--�ð���� ����

        //ī�޶� �ٶ󺸴� �������� ��ȸ
        Vector3 tDir = Camera.main.transform.forward;
        tDir.y = 0f;
        //ī�޶� ������ ������ ������ ���Ѵ�.
        Vector3 tLookAtPosition = this.transform.position + tDir;
        //ī�޶� ���� ������ ������ ������ �ٶ󺸰� �Ѵ�.
        this.transform.LookAt(tLookAtPosition);

    }
}
