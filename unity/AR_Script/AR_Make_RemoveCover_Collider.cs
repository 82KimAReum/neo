using UnityEditor; //이 부분만 추가해준다.
using UnityEngine;

public class AR_Make_RemoveCover_Collider : MonoBehaviour
{
    // 메뉴창에 추가
    //[MenuItem("Tools/AR/Make Fade Collider", false, 0)]
    private static void AR_Make_RemoveCover_ColliderCommand(MenuCommand menuCommand)
    {
        // 선택한 오브젝트
        Transform[] selectedTransforms = Selection.transforms;

        // 선택된 것이 없으면 종료
        if (selectedTransforms.Length == 0) return;
        foreach (Transform selectedTransform in selectedTransforms)
        {
            if (selectedTransform.childCount > 0) continue;
            copy_Transform(selectedTransform);
        }
    }

    public static bool copy_Transform(Transform selectedTransform)
    {
        //원본에 커버삭제 스크립트 추가 
        insert_C_ObjRemoveCoverScript(selectedTransform);
        check_meshMaterials(selectedTransform);//메테리얼 cover_meterial로 변경

        // 오브젝트 복사
        GameObject copiedObject = Instantiate(selectedTransform.gameObject, selectedTransform.parent);

        // 복사 이름 설정
        //copiedObject.name = selectedTransform.gameObject.name + " (Copy)";
        copiedObject.name = "Range";

        // 복사의 부모 설정
        copiedObject.transform.SetParent(selectedTransform.transform);

        // Range에 박스 콜라이더 추가
        BoxCollider boxCollider = copiedObject.GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            boxCollider = copiedObject.AddComponent<BoxCollider>();
        }

        // 포지션 설정
        //copiedObject.transform.localPosition = new Vector3(0, 0, 0.5f);

        if (boxCollider != null)
        {

            // Is Trigger 값을 true로 변경
            boxCollider.isTrigger = true;
        }
        else
        {
            //Debug.LogWarning("Box Collider 컴포넌트를 찾을 수 없습니다.");
        }

        // Range의 MeshRenderer 컴포넌트 가져오기
        MeshRenderer[] meshRenderers = copiedObject.gameObject.GetComponentsInChildren<MeshRenderer>();

        // 가져온 MeshRenderer 컴포넌트 삭제
        foreach (MeshRenderer renderer in meshRenderers)
        {
            DestroyImmediate(renderer);
        }

        // Range의 MeshFilter 컴포넌트 가져오기
        MeshFilter meshFilter = copiedObject.gameObject.GetComponent<MeshFilter>();

        // 가져온 MeshFilter 컴포넌트 삭제
        if (meshFilter != null)
        {
            DestroyImmediate(meshFilter);
        }

        // 오브젝트의 레이어를 'UI'로 변경
        copiedObject.layer = LayerMask.NameToLayer("Range");//Range로 변경할것!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        //
        insert_CRangeTrigger(copiedObject);

        delete_C_ObjRemoveCoverScript(copiedObject);
        delete_mesh_componenet(copiedObject);

        insert_C_ObjRemoveCover_range(selectedTransform);
        

        return true;
    }


    static void insert_CRangeTrigger(GameObject obj)
    {
        CRangeTrigger crt = obj.AddComponent<CRangeTrigger>();
        //crt.ins_emActType = EmPoolType.Size;
        //crt.ins_emRangeType = CRange.EmRangeType.Size;
        //crt.ins_emColRangeType = CRange.EmColliderType.Box;
        crt.ins_emActType = EmPoolType.Emotion;
        crt.ins_emRangeType = CRange.EmRangeType.Alert;
        crt.ins_emColRangeType = CRange.EmColliderType.Box;

        crt.m_fStopOffset = 0;
        // 스피어 오프셋에 대한 정보가 없는데 파일 정보가 덜 배달 온듯 .
        // 니가 확인 
    }

    static void delete_C_ObjRemoveCoverScript(GameObject obj)
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

        CObjRemoveCover objRemoveComponent = obj.GetComponent<CObjRemoveCover>();
        if (objRemoveComponent != null)
        {
            DestroyImmediate(objRemoveComponent);
        }
        else
        {
            //Debug.LogWarning("C Obj Fade 컴포넌트를 찾을 수 없습니다.");
        }

    }

    static void insert_C_ObjRemoveCoverScript(Transform obj)
    {//부모에게 C_ObjFade 컴포넌츠 붙이고 , ins_rnaderer값셋팅


        delete_C_ObjRemoveCoverScript(obj.gameObject);

        CObjRemoveCover crc = obj.gameObject.AddComponent<CObjRemoveCover>();
        crc.ins_Renderer = obj.gameObject.GetComponentsInChildren<MeshRenderer>();
    }


    static void insert_C_ObjRemoveCover_range(Transform obj)
    {
        CObjRemoveCover crt = obj.GetComponent<CObjRemoveCover>();

        foreach (Transform child in obj)
        {
            if (child.name == "Range")
            {
                CRangeTrigger crt2 = child.GetComponent<CRangeTrigger>();
                crt.ins_scrRange = crt2;
            }

        }
    }


    static void delete_mesh_componenet(GameObject obj)
    {
        //메시콜라이더 삭제
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

    static void check_meshMaterials(Transform obj)
    {
        //메터리얼 페이드인지 확인후 아니면 변경

        // 선택된 객체에 MeshRenderer 컴포넌트가 있는지 확인
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            // MeshRenderer가 존재하면 첫 번째 Shared Material 가져오기
            Material sharedMaterial = meshRenderer.sharedMaterial;

            // Shared Material 이름 끝에 "fade"가 포함되어 있는지 확인
            if (sharedMaterial.name.ToLower().StartsWith("cover"))
            {
                //Debug.Log("컴포넌트 이름이 'cover'로 시작합니다.");
            }
            else
            {
                Debug.Log(obj.name+" 메터리얼이 'cover'로 시작하지 않습니다. 현재: "+ sharedMaterial.name);
                // 선택된 객체의 Shared Material 이름에 "cover" 추가한 Material이 있는지 검색
                string newMaterialName = "cover_material";
                Material newMaterial = FindMaterialInScene(newMaterialName);

                if (newMaterial != null)
                {
                    meshRenderer.material = newMaterial;
                    Debug.Log(obj.name + " cover메터리얼로 어사인 함");
                }
                else
                {

                    Debug.LogError(obj.name + " cover메터리얼로 어사인 실패");
                }
            }
        }
        else
        {
            Debug.Log(obj.name + "해당오브젝트는 메시렌더러가 없습니다. ");
        }
    
}

    // 씬에서 이름에 맞는 Material을 검색하는 함수
    static Material FindMaterialInScene(string materialName)
    {
        Material[] allMaterials = Resources.FindObjectsOfTypeAll<Material>();

        foreach (Material mat in allMaterials)
        {
            if (mat.name == materialName)
            {
                return mat;
            }
        }

        return null;
    }

}
