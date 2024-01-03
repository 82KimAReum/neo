using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Animation_delete_action3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private static Quaternion savedRotation;
    public static void _delete_action(Transform selectedTransform)
    {


        // ���õ� ������Ʈ�� null�� �ƴϸ�
        if (selectedTransform != null)
        {
            // ������Ʈ�� �ڽĵ��� �����ɴϴ�.
            Transform[] childTransforms = selectedTransform.GetComponentsInChildren<Transform>();
            // ���õ� ���� ������Ʈ�� �θ�
            Transform parentTransform = selectedTransform.transform.parent;


            //foreach (Transform child in childTransforms)
            //{
            //    if (child != selectedTransform.transform && child.name.Contains("Rotation"))
                   
            //    {
            //        savedRotation = child.localRotation;
            //    }

            //}
            foreach (Transform child in childTransforms)
            {
                if (child != selectedTransform.transform && !child.name.Contains("Rotation") && savedRotation != null)
                {
                    // �ڽ��� �θ� ���õ� ���� ������Ʈ�� �θ�� ����
                    child.SetParent(parentTransform);

                    // ���� ��ġ�� �����ϵ��� ���� ��ġ�� ���� + ȸ���� ����
                    //child.localPosition = selectedTransform.localPosition;
                    //child.localRotation= savedRotation;

                }

            }


            // ���õ� ������Ʈ�� �����մϴ�.
            DestroyImmediate(selectedTransform.gameObject);

            // �ڽ� ������Ʈ���� �״�� �����ϴ�.
            Debug.Log("���õ� ������Ʈ�� �����Ǿ����ϴ�. �ڽ� ������Ʈ�� �״�� �����ϴ�.");

            // ���õ� ������Ʈ�� null�� �����Ͽ� �ν����Ϳ��� ������ ���� �� �ֵ��� �մϴ�.
            selectedTransform = null;
        }
        else
        {
            Debug.LogError("�����Ϸ��� ������Ʈ�� �������� �ʾҽ��ϴ�.");
        }
    }

}
