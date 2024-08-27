using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPChar_step_0 : MonoBehaviour
{
    //�̸� ������ ��Ƶξ� ���� ������ ����
    Transform mTransform = null;

    [SerializeField] float mSpeedRotate = 0f;//public���� ���� ����ȭ�� �����ʾƼ� �ٸ��������� �����ؾ��ϹǷ� �̽��� �߻�����
    //[SerializeField]�� ���� ����Ƽ �����Ϳ� ���ս��� �ݺ������� �����ϰ� ���ش�.
    //���� �ش� ������ privte�̹Ƿ� ����ȭencapsulation �޼�
    [SerializeField] float mSpeedForward = 0f;


    // Start is called before the first frame update
    void Start()
    {
        mTransform = this.transform;//������ ĳ�ÿ��д�.(�̸� �����صд�.)
    }

    // Update is called once per frame
    void Update()
    {
        //���Է�
        float tV = Input.GetAxis("Vertical"); //[-1, +1]
        float tH = Input.GetAxis("Horizontal");

        //�¿� ��ȸ
        //Rotate�Լ��� '�����'�� ������� �۵��Ѵ�.
        this.transform.Rotate(Vector3.up,tH * mSpeedRotate * Time.deltaTime);

        //�ӵ� = �Ÿ��� ��ȭ��/�ð��Ǻ�ȭ��.    �����̴�.
        //Vector3 tVelocity = Vector3.zero;//�����ͷ� �ʱ�ȭ
        //tVelocity = Vector3.forward * 10.0f * tV * Time.deltaTime; //������ ��Į�� ����
        ////������ �ð��� ���Ͽ� �ð���� ������ �Ѵ�.
        //mTransform.Translate(tVelocity,Space.Self);//local ��ǥ�� �������� �ӵ� ����
        
        //mTransform.Translate(tVelocity,Space.World);//World ��ǥ�� �������� �ӵ� ����
        ////mTransform.Translate(tVelocity,Space.Self);//local ��ǥ�� �������� �ӵ� ����//�ӵ� = �Ÿ��� ��ȭ��/�ð��Ǻ�ȭ��.    �����̴�.
        Vector3 tVelocity = Vector3.zero;//�����ͷ� �ʱ�ȭ
        tVelocity = mTransform.forward * mSpeedForward * tV * Time.deltaTime; //������ ��Į�� ����


        //�����Ͱ� �ƴϸ� �̵�
        if(!tVelocity.Equals(Vector3.zero))
        {
            //������ �ð��� ���Ͽ� �ð���� ������ �Ѵ�.
            mTransform.Translate(tVelocity, Space.World);//World ��ǥ�� �������� �ӵ� ����
        }

        //Transform.forward�� ������ǥ�� ���� ���溤�͸� ������ǥ�� ������ ��ġ�� ��Ÿ�� �� 


        /*
         ���ӿ������� �̵��� �����ϴ� ��� ���
        i) ���� ��ǥ�� �����ϴ� ���
            
            ������ǥ = ������ǥ + �ӵ� * �ð�����
            <-- ���Ϸ� ��ġ�ؼ� ����� ���� �̵�

        ���� ���α׷��� ������ ���� ����Ȯ�ص� ������ ���� ���� �����Ͽ�
        ���Ϸ� ��ġ�ؼ��� ���� �̵������ ����.

        ii) ���ӿ������� �����ϴ� �̵��Լ��� �̿��ϴ� ���
        iii) ���������� �̿��ϴ� ���

        iv) �ִϸ��̼� �ȿ� �̵��� �����ϴ� ���
         */
    }
}
