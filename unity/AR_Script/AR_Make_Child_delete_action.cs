using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Make_Child_delete_action : MonoBehaviour
{
    // Start is called before the first frame update
    public static void _delete_action(Transform selectedTransform)
    {
        // 현재 선택된 게임 오브젝트의 자식 개수 확인
        int childCount = selectedTransform.childCount;

        if (childCount > 0)
        {
            // 모든 자식 삭제
            for (int i = childCount - 1; i >= 0; i--)
            {
                // DestroyImmediate를 사용하여 즉시 삭제
                DestroyImmediate(selectedTransform.GetChild(i).gameObject);
            }

            Debug.Log("자식 오브젝트가 삭제되었습니다.");
        }
        else
        {
            Debug.Log("자식 오브젝트가 없습니다.");
        }
    }
}
