using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Make_Child_delete_action : MonoBehaviour
{
    // Start is called before the first frame update
    public static void _delete_action(Transform selectedTransform)
    {
        // ���� ���õ� ���� ������Ʈ�� �ڽ� ���� Ȯ��
        int childCount = selectedTransform.childCount;

        if (childCount > 0)
        {
            // ��� �ڽ� ����
            for (int i = childCount - 1; i >= 0; i--)
            {
                // DestroyImmediate�� ����Ͽ� ��� ����
                DestroyImmediate(selectedTransform.GetChild(i).gameObject);
            }

            Debug.Log("�ڽ� ������Ʈ�� �����Ǿ����ϴ�.");
        }
        else
        {
            Debug.Log("�ڽ� ������Ʈ�� �����ϴ�.");
        }
    }
}
