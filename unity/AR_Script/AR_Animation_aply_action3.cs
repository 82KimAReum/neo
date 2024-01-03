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

    // ��ġ�� �׷� copiedObject
    // �ִ� emptyAni
    // ���� selectedTransform
    {
        // ���� �����ؼ� ��ġ�� �׷� ����
        GameObject copiedObject = Instantiate(selectedTransform.gameObject, selectedTransform.parent);

        // Transform�� �����̼��� (0, 0, 0)���� �����մϴ�.
        //copiedObject.transform.rotation = Quaternion.identity;

        // Transform�� �������� (1, 1, 1)�� �����մϴ�.
        //copiedObject.transform.localScale = Vector3.one;

        delete_Component(copiedObject);

        // ���� �̸� ����
        copiedObject.name = "Ani_" + GetModelName2(selectedTransform.gameObject.name);
        //copiedObject.name = "Range";

        // ������ ��ġ�� (0, 0, 0)���� �����մϴ�./////////////////////////////////////////////////////////////////////////////////////////////////////////
        //selectedTransform.localPosition = Vector3.zero;
        //selectedTransform.localPosition = new Vector3(0f, -0.6f, 0f);
        //selectedTransform.localPosition = new Vector3(rotation3.x * -1, rotation3.y * -1, rotation3.z * -1);

        //selectedTransform.transform.localRotation = Quaternion.identity;

        // ���� �����ؼ� ��ġ�� �׷� ����
        GameObject emptyAni = Instantiate(selectedTransform.gameObject, selectedTransform.parent);
        delete_Component(emptyAni);
        emptyAni.name = "Rotation_" + GetModelName(selectedTransform.gameObject.name);



        //��Ƽ������Ʈ ���� //

        emptyAni.transform.SetParent(copiedObject.transform);
  
        //emptyAni.transform.localRotation = selectedTransform.transform.localRotation;

        //������ ȸ����-> ��Ƽ ������Ʈ�� �ְ�, ������ 0,0,0 ���� 
        //������ ȸ����-> ��Ƽ ������Ʈ�� �ְ�, ������ 0,0,0 ���� 




        // ������ �θ� ����
        //copiedObject.transform.SetParent(selectedTransform.transform);
        selectedTransform.transform.SetParent(emptyAni.transform);


        Quaternion newQuaternion = Quaternion.Euler(rotation3.x * -1, rotation3.y * -1, rotation3.z * -1);
        emptyAni.transform.localPosition = rotation3;
        //selectedTransform.transform.localRotation = newQuaternion;
        selectedTransform.localPosition = new Vector3(rotation3.x * -1, rotation3.y * -1, rotation3.z * -1);
        //selectedTransform.transform.localPosition=



        // ��Ƽ������Ʈ ��ġ�� (0, 0, 0)���� �����մϴ�./////////////////////////////////////////////////////////////////////////////////////////////////////////
        //emptyAni.transform.localPosition = Vector3.zero;
        //emptyAni.transform.localPosition = new Vector3(0f, 0.6f, 0f);


        //selectedTransform.transform.localRotation = Quaternion.identity;






        // �� ��ũ��Ʈ�� �߰��� ���� ������Ʈ�� �ִϸ����� ������Ʈ�� �߰��մϴ�.
        Animator animator = emptyAni.AddComponent<Animator>();
        animator.applyRootMotion = true;
        //// ���� �ִϸ����� ������Ʈ�� ���������� �߰��Ǿ��ٸ�, �ʿ��� ������ �� �� �ֽ��ϴ�.
        //if (animator != null)
        //{
        //    // �ִϸ��̼� ��Ʈ�ѷ��� �Ҵ��ϰų� �ٸ� ������ ������ �� �ֽ��ϴ�.
        //    // animator.runtimeAnimatorController = yourController;


        //    // �� ��ũ��Ʈ�� �߰��� ���� ������Ʈ�� Animator ������Ʈ�� �����ɴϴ�.
        //    Animator animator_Comp = emptyAni.GetComponent<Animator>();



        //    // Animator ������Ʈ�� �ִ��� Ȯ���մϴ�.
        //    if (animator_Comp != null)
        //    {
        //        // "chain_b_rotation" �ִϸ��̼� ��Ʈ�ѷ��� Resources �������� �ε��մϴ�.
        //        //RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>("chain_b_rotation");
        //        RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>(controllerPath);
        //        //RuntimeAnimatorController controller = (RuntimeAnimatorController)AssetDatabase.LoadAssetAtPath(controllerPath, typeof(RuntimeAnimatorController));

        //        Debug.LogError("��Ʈ�ѷ��н�." + controllerPath);
        //        Debug.LogError("��Ʈ�ѷ�."+ controller.name);
        //        // �ִϸ��̼� ��Ʈ�ѷ��� �Ҵ��մϴ�.
        //        animator_Comp.runtimeAnimatorController = controller;

        //        if (controller != null)
        //        {
        //            Debug.Log("�ִϸ��̼� ��Ʈ�ѷ��� �Ҵ��߽��ϴ�.");
        //        }
        //        else
        //        {
        //            Debug.LogError("�ִϸ��̼� ��Ʈ�ѷ��� �ε����� ���߽��ϴ�. ��θ� Ȯ���ϼ���" + controllerPath);
        //        }
        //    }
        //    else
        //    {
        //        Debug.LogError("Animator ������Ʈ�� ã�� �� �����ϴ�.");
        //    }


        //}
        //else
        //{
        //    Debug.LogError("�ִϸ����� ������Ʈ�� �߰��ϴ� �� ������ �߻��߽��ϴ�.");
        //}





        return true;
    }

    static string GetModelName(string fullName)
    {
        // ���Խ��� ����Ͽ� "model(nn)" �κ��� ã���ϴ�.
        string pattern = @"_model(\d+)?";
        string result = Regex.Replace(fullName, pattern, "").Trim();

        return result;
    }

    static string GetModelName2(string fullName)
    {
        // ���Խ��� ����Ͽ� "model" �κ��� �����ϰ� ���� ���ڸ� �����ɴϴ�.
        string pattern = @"_model(\d+)?";
        Match match = Regex.Match(fullName, pattern);

        // "model" �κ��� �����ϰ� ���� ���ڸ� �����ɴϴ�.
        //string extractedNumber = match.Success ? match.Groups[1].Value : "";

        // "model" �κ��� �����ϰ� ���� ���ڸ� ���� ���ڿ��� �ٿ��� ��ȯ�մϴ�.
        return fullName.Replace("_model", "") ;
    }

    static void delete_Component(GameObject obj)
    {

        // GameObject�� ������ ��� ������Ʈ�� �����ɴϴ�.
        Component[] components = obj.transform.GetComponents<Component>();

        // Transform ������Ʈ�� ������ ��� ������Ʈ�� �����մϴ�.
        foreach (var component in components)
        {
            if (!(component is Transform))
            {
                DestroyImmediate(component);
            }
        }
        // MeshRenderer ������Ʈ ����
        MeshRenderer meshRenderer = obj.transform.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            DestroyImmediate(meshRenderer);
        }
        // Mesh ������Ʈ ����
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