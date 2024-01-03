using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;

public class AR_Animation_aply_action3 : MonoBehaviour
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
        //copiedObject.transform.rotation = Quaternion.identity;

        // Transform의 스케일을 (1, 1, 1)로 설정합니다.
        //copiedObject.transform.localScale = Vector3.one;

        delete_Component(copiedObject);

        // 복사 이름 설정
        copiedObject.name = "Ani_" + GetModelName2(selectedTransform.gameObject.name);
        //copiedObject.name = "Range";

        // 원본의 위치를 (0, 0, 0)으로 변경합니다./////////////////////////////////////////////////////////////////////////////////////////////////////////
        //selectedTransform.localPosition = Vector3.zero;
        //selectedTransform.localPosition = new Vector3(0f, -0.6f, 0f);
        //selectedTransform.localPosition = new Vector3(rotation3.x * -1, rotation3.y * -1, rotation3.z * -1);

        //selectedTransform.transform.localRotation = Quaternion.identity;

        // 원본 복사해서 위치값 그룹 생성
        GameObject emptyAni = Instantiate(selectedTransform.gameObject, selectedTransform.parent);
        delete_Component(emptyAni);
        emptyAni.name = "Rotation_" + GetModelName(selectedTransform.gameObject.name);



        //엠티오브젝트 생성 //

        emptyAni.transform.SetParent(copiedObject.transform);
  
        //emptyAni.transform.localRotation = selectedTransform.transform.localRotation;

        //원본의 회전값-> 엠티 오브젝트에 넣고, 원본은 0,0,0 으로 
        //원본의 회전값-> 엠티 오브젝트에 넣고, 원본은 0,0,0 으로 




        // 복사의 부모 설정
        //copiedObject.transform.SetParent(selectedTransform.transform);
        selectedTransform.transform.SetParent(emptyAni.transform);


        Quaternion newQuaternion = Quaternion.Euler(rotation3.x * -1, rotation3.y * -1, rotation3.z * -1);
        emptyAni.transform.localPosition = rotation3;
        //selectedTransform.transform.localRotation = newQuaternion;
        selectedTransform.localPosition = new Vector3(rotation3.x * -1, rotation3.y * -1, rotation3.z * -1);
        //selectedTransform.transform.localPosition=



        // 엠티오브젝트 위치를 (0, 0, 0)으로 변경합니다./////////////////////////////////////////////////////////////////////////////////////////////////////////
        //emptyAni.transform.localPosition = Vector3.zero;
        //emptyAni.transform.localPosition = new Vector3(0f, 0.6f, 0f);


        //selectedTransform.transform.localRotation = Quaternion.identity;






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

    static string GetModelName(string fullName)
    {
        // 정규식을 사용하여 "model(nn)" 부분을 찾습니다.
        string pattern = @"_model(\d+)?";
        string result = Regex.Replace(fullName, pattern, "").Trim();

        return result;
    }

    static string GetModelName2(string fullName)
    {
        // 정규식을 사용하여 "model" 부분을 제외하고 뒤의 숫자를 가져옵니다.
        string pattern = @"_model(\d+)?";
        Match match = Regex.Match(fullName, pattern);

        // "model" 부분을 제외하고 뒤의 숫자를 가져옵니다.
        //string extractedNumber = match.Success ? match.Groups[1].Value : "";

        // "model" 부분을 제외하고 뒤의 숫자를 앞의 문자열에 붙여서 반환합니다.
        return fullName.Replace("_model", "") ;
    }

    static void delete_Component(GameObject obj)
    {

        // GameObject에 부착된 모든 컴포넌트를 가져옵니다.
        Component[] components = obj.transform.GetComponents<Component>();

        // Transform 컴포넌트를 제외한 모든 컴포넌트를 제거합니다.
        foreach (var component in components)
        {
            if (!(component is Transform))
            {
                DestroyImmediate(component);
            }
        }
        // MeshRenderer 컴포넌트 삭제
        MeshRenderer meshRenderer = obj.transform.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            DestroyImmediate(meshRenderer);
        }
        // Mesh 컴포넌트 삭제
        MeshFilter meshFilter = obj.transform.GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            DestroyImmediate(meshFilter);
        }

    }





    static void create_(GameObject obj)
    {


    }

}