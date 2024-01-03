using UnityEditor; //이 부분만 추가해준다.
using UnityEngine;

public class AR_Delete_RemoveCover_Collider : MonoBehaviour
{
    // 메뉴창에 추가
    //[MenuItem("Tools/AR/Make Delete Collider", false, 0)]
    private static void AR_Delete_RemoveCover_ColliderCommand(MenuCommand menuCommand)
    {
        // 선택한 오브젝트
        Transform[] selectedTransforms = Selection.transforms;

        // 선택된 것이 없으면 종료
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

        DeleteDescendantsRecursive(selectedTransform);//자손(Range)삭제

        delete_C_ObjRemoveCover(selectedTransform.gameObject);
        delete_mesh_componenet(selectedTransform.gameObject);



        return true;
    }

    static void delete_C_ObjRemoveCover(GameObject obj)
    {
        // "C Obj Fade" 스크립트 컴포넌트 삭제
        //CObjFade objFadeComponent = obj.GetComponent<CObjFade>();
        //if (objFadeComponent != null)
        //{
        //    DestroyImmediate(objFadeComponent);
        //}
        //else
        //{
        //    Debug.LogWarning("C Obj Fade 컴포넌트를 찾을 수 없습니다.");
        //}
       // "C Obj Remove Cover" 스크립트 컴포넌트 삭제
       CObjRemoveCover orc = obj.GetComponent<CObjRemoveCover>();
        if (orc != null)
        {
            DestroyImmediate(orc);
        }
        else
        {
            Debug.LogError(obj.name+ " CObjRemoveCover 컴포넌트를 찾을 수 없습니다.");
        }

    }



    static void delete_mesh_componenet(GameObject obj)
    {
        // "C Obj Fade" 스크립트 컴포넌트 삭제
        //CObjFade objFadeComponent = obj.GetComponent<CObjFade>();
        MeshCollider meshCollider = obj.GetComponent<MeshCollider>();
        if (meshCollider != null)
        {
            DestroyImmediate(meshCollider);
        }
        else
        {
            Debug.LogWarning("meshCollider 컴포넌트를 찾을 수 없습니다.");
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
