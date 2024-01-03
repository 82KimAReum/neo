using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AR_Animation_aply_action : MonoBehaviour
{
    //Your/Controller/Path/
    //public static string controllerPath = "Assets/_ArtProject/Map/map_gl_data/map_data/gl_prison/Animation/chain_b_rotation";
    //public static string controllerPath = "AR_temp_be_deleted/chain_b_rotation";


    public static bool copy_Transform(Transform selectedTransform, Vector3 rotation3)

    // 위치값 그룹 copiedObject
    // 애니 emptyAni
    // 원본 selectedTransform
    {
        // 원본 복사해서 위치값 그룹 생성
        GameObject copiedObject = Instantiate(selectedTransform.gameObject, selectedTransform.parent);

        // Transform의 로테이션을 (0, 0, 0)으로 설정합니다.
        copiedObject.transform.rotation = Quaternion.identity;

        // Transform의 스케일을 (1, 1, 1)로 설정합니다.
        copiedObject.transform.localScale = Vector3.one;

        // GameObject에 부착된 모든 컴포넌트를 가져옵니다.
        Component[] components = copiedObject.transform.GetComponents<Component>();

        // Transform 컴포넌트를 제외한 모든 컴포넌트를 제거합니다.
        foreach (var component in components)
        {
            if (!(component is Transform))
            {
                DestroyImmediate(component);
            }
        }
        // MeshRenderer 컴포넌트 삭제
        MeshRenderer meshRenderer = copiedObject.transform.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            DestroyImmediate(meshRenderer);
        }
        // Mesh 컴포넌트 삭제
        MeshFilter meshFilter = copiedObject.transform.GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            DestroyImmediate(meshFilter);
        }


        // 복사 이름 설정
        copiedObject.name = selectedTransform.gameObject.name + "_Ani";
        //copiedObject.name = "Range";

        // 원본의 위치를 (0, 0, 0)으로 변경합니다./////////////////////////////////////////////////////////////////////////////////////////////////////////
        //selectedTransform.localPosition = Vector3.zero;
        //selectedTransform.localPosition = new Vector3(0f, -0.6f, 0f);
        selectedTransform.localPosition = new Vector3(rotation3.x * -1, rotation3.y * -1, rotation3.z * -1);
        //selectedTransform.transform.localRotation = Quaternion.identity;



        //엠티오브젝트 생성 //
        GameObject emptyAni = new GameObject("Rotation_"+ selectedTransform.gameObject.name);
        

        // 복사의 부모 설정
        //copiedObject.transform.SetParent(selectedTransform.transform);
        selectedTransform.transform.SetParent(emptyAni.transform);
        emptyAni.transform.SetParent(copiedObject.transform);


        // 엠티오브젝트 위치를 (0, 0, 0)으로 변경합니다./////////////////////////////////////////////////////////////////////////////////////////////////////////
        //emptyAni.transform.localPosition = Vector3.zero;
        //emptyAni.transform.localPosition = new Vector3(0f, 0.6f, 0f);
        emptyAni.transform.localPosition = rotation3;
        //emptyAni.transform.localRotation = Quaternion.identity;






        // 이 스크립트가 추가된 게임 오브젝트에 애니메이터 컴포넌트를 추가합니다.
        Animator animator = emptyAni.AddComponent<Animator>();
        animator.applyRootMotion = true;
        //// 만약 애니메이터 컴포넌트가 성공적으로 추가되었다면, 필요한 설정을 할 수 있습니다.
        //if (animator != null)
        //{
        //    // 애니메이션 컨트롤러를 할당하거나 다른 설정을 수행할 수 있습니다.
        //    // animator.runtimeAnimatorController = yourController;


        //    // 이 스크립트가 추가된 게임 오브젝트의 Animator 컴포넌트를 가져옵니다.
        //    Animator animator_Comp = emptyAni.GetComponent<Animator>();



        //    // Animator 컴포넌트가 있는지 확인합니다.
        //    if (animator_Comp != null)
        //    {
        //        // "chain_b_rotation" 애니메이션 컨트롤러를 Resources 폴더에서 로드합니다.
        //        //RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>("chain_b_rotation");
        //        RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>(controllerPath);
        //        //RuntimeAnimatorController controller = (RuntimeAnimatorController)AssetDatabase.LoadAssetAtPath(controllerPath, typeof(RuntimeAnimatorController));

        //        Debug.LogError("컨트롤러패스." + controllerPath);
        //        Debug.LogError("컨트롤러."+ controller.name);
        //        // 애니메이션 컨트롤러를 할당합니다.
        //        animator_Comp.runtimeAnimatorController = controller;

        //        if (controller != null)
        //        {
        //            Debug.Log("애니메이션 컨트롤러를 할당했습니다.");
        //        }
        //        else
        //        {
        //            Debug.LogError("애니메이션 컨트롤러를 로드하지 못했습니다. 경로를 확인하세요" + controllerPath);
        //        }
        //    }
        //    else
        //    {
        //        Debug.LogError("Animator 컴포넌트를 찾을 수 없습니다.");
        //    }


        //}
        //else
        //{
        //    Debug.LogError("애니메이터 컴포넌트를 추가하는 데 문제가 발생했습니다.");
        //}





        return true;
    }




    static void delete_(GameObject obj)
    {
     
    }





    static void create_(GameObject obj)
    {


    }

}