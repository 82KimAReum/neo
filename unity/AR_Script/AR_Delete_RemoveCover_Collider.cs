using UnityEditor; //�� �κи� �߰����ش�.
using UnityEngine;

public class AR_Delete_RemoveCover_Collider : MonoBehaviour
{
    // �޴�â�� �߰�
    //[MenuItem("Tools/AR/Make Delete Collider", false, 0)]
    private static void AR_Delete_RemoveCover_ColliderCommand(MenuCommand menuCommand)
    {
        // ������ ������Ʈ
        Transform[] selectedTransforms = Selection.transforms;

        // ���õ� ���� ������ ����
        if (selectedTransforms.Length == 0) return;
        foreach (Transform selectedTransform in selectedTransforms)
        {
            if (selectedTransform.childCount > 0) continue;
            delete_Transform(selectedTransform);
        }
    }

    public static bool delete_Transform(Transform selectedTransform)
    {
        //Debug.LogWarning("delete_Transform called");

        DeleteDescendantsRecursive(selectedTransform);//�ڼ�(Range)����

        delete_C_ObjRemoveCover(selectedTransform.gameObject);
        delete_mesh_componenet(selectedTransform.gameObject);



        return true;
    }

    static void delete_C_ObjRemoveCover(GameObject obj)
    {
        // "C Obj Fade" ��ũ��Ʈ ������Ʈ ����
        //CObjFade objFadeComponent = obj.GetComponent<CObjFade>();
        //if (objFadeComponent != null)
        //{
        //    DestroyImmediate(objFadeComponent);
        //}
        //else
        //{
        //    Debug.LogWarning("C Obj Fade ������Ʈ�� ã�� �� �����ϴ�.");
        //}
       // "C Obj Remove Cover" ��ũ��Ʈ ������Ʈ ����
       CObjRemoveCover orc = obj.GetComponent<CObjRemoveCover>();
        if (orc != null)
        {
            DestroyImmediate(orc);
        }
        else
        {
            Debug.LogError(obj.name+ " CObjRemoveCover ������Ʈ�� ã�� �� �����ϴ�.");
        }

    }



    static void delete_mesh_componenet(GameObject obj)
    {
        // "C Obj Fade" ��ũ��Ʈ ������Ʈ ����
        //CObjFade objFadeComponent = obj.GetComponent<CObjFade>();
        MeshCollider meshCollider = obj.GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            DestroyImmediate(meshCollider);
        }
        else
        {
            Debug.LogWarning("meshCollider ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }



    /////
    ///
    static void DeleteDescendantsRecursive(Transform parent)
    {
        int childCount = parent.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = parent.GetChild(i);
            DeleteDescendantsRecursive(child);
            DestroyImmediate(child.gameObject);
        }
    }

}
