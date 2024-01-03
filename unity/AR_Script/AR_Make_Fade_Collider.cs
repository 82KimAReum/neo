using UnityEditor; //�� �κи� �߰����ش�.
using UnityEngine;

public class AR_Make_Fade_Collider : MonoBehaviour
{
    // �޴�â�� �߰�
    [MenuItem("Tools/AR/Make Fade Collider", false, 0)]
    private static void AR_Make_Fade_ColliderCommand(MenuCommand menuCommand)
    {
        // ������ ������Ʈ
        Transform[] selectedTransforms = Selection.transforms;

        // ���õ� ���� ������ ����
        if (selectedTransforms.Length == 0) return;
        foreach (Transform selectedTransform in selectedTransforms)
        {
            if (selectedTransform.childCount > 0) continue;
            copy_Transform(selectedTransform);
        }
    }

    public static bool copy_Transform(Transform selectedTransform)
    {
        //������ ������Ʈ ���̵� ��ũ��Ʈ �߰� 
        insert_C_ObjFade_fadeMash(selectedTransform);
        check_meshMaterials(selectedTransform);

        // ������Ʈ ����
        GameObject copiedObject = Instantiate(selectedTransform.gameObject, selectedTransform.parent);

        // ���� �̸� ����
        //copiedObject.name = selectedTransform.gameObject.name + " (Copy)";
        copiedObject.name = "Range";

        // ������ �θ� ����
        copiedObject.transform.SetParent(selectedTransform.transform);

        // empty�� �ڽ� �ݶ��̴� �߰�
        BoxCollider boxCollider = copiedObject.GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            boxCollider = copiedObject.AddComponent<BoxCollider>();
        }

        // ������ ����
        //copiedObject.transform.localPosition = new Vector3(0, 0, 0.5f);

        if (boxCollider != null)
        {
            // ���� �ڽ� �ݶ��̴��� ��ġ
            Vector3 colliderPosition = boxCollider.center;
            Vector3 colliderSize = boxCollider.size;
            float ori_collSizeY = colliderSize.y;
            float ori_collSizeZ = colliderSize.z;
            colliderSize.y = 0.28f;
            colliderSize.z = 0.28f;
            boxCollider.size = colliderSize;
            colliderPosition.y -= (ori_collSizeY/2+(colliderSize.y/2));
            colliderPosition.z -= (ori_collSizeZ / 2 - (colliderSize.z/2));



            // y ��ġ�� 0.5��ŭ ����
            //colliderPosition.y += (-0.5f);

            // ����� ��ġ�� �ڽ� �ݶ��̴��� ��ġ ������Ʈ
            boxCollider.center = colliderPosition;

            // Is Trigger ���� true�� ����
            boxCollider.isTrigger = true;
        }
        else
        {
            Debug.LogWarning("Box Collider ������Ʈ�� ã�� �� �����ϴ�.");
        }

        // ������Ʈ�� �ִ� ��� MeshRenderer ������Ʈ ��������
        MeshRenderer[] meshRenderers = copiedObject.gameObject.GetComponentsInChildren<MeshRenderer>();

        // ������ MeshRenderer ������Ʈ ����
        foreach (MeshRenderer renderer in meshRenderers)
        {
            DestroyImmediate(renderer);
        }

        // ������Ʈ�� �ִ� MeshFilter ������Ʈ ��������
        MeshFilter meshFilter = copiedObject.gameObject.GetComponent<MeshFilter>();

        // ������ MeshFilter ������Ʈ ����
        if (meshFilter != null)
        {
            DestroyImmediate(meshFilter);
        }

        // ������Ʈ�� ���̾ 'UI'�� ����
        copiedObject.layer = LayerMask.NameToLayer("Range");//Range�� �����Ұ�!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        //
        insert_CRangeTrigger(copiedObject);

        delete_C_ObjFade(copiedObject);
        delete_mesh_componenet(copiedObject);

        insert_C_ObjFade_range(selectedTransform);
        

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
        // ���Ǿ� �����¿� ���� ������ ���µ� ���� ������ �� ��� �µ� .
        // �ϰ� Ȯ�� 
    }

    static void delete_C_ObjFade(GameObject obj)
    {
        // "C Obj Fade" ��ũ��Ʈ ������Ʈ ����
        CObjFade objFadeComponent = obj.GetComponent<CObjFade>();
        if (objFadeComponent != null)
        {
            DestroyImmediate(objFadeComponent);
        }
        else
        {
            Debug.LogWarning("C Obj Fade ������Ʈ�� ã�� �� �����ϴ�.");
        }
    }

    static void insert_C_ObjFade_fadeMash(Transform obj)
    {//�θ𿡰� C_ObjFade �������� ���̰� , ins_rnaderer������


        delete_C_ObjFade(obj.gameObject);

        CObjFade crt = obj.gameObject.AddComponent<CObjFade>();
        crt.ins_Renderer = obj.gameObject.GetComponentsInChildren<MeshRenderer>();
    }

    static void insert_C_ObjFade_range(Transform obj)
    {
        CObjFade crt = obj.GetComponent<CObjFade>();

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
        //�޽��ݶ��̴� ����
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

    static void check_meshMaterials(Transform obj)
    {
        //���͸��� ���̵����� Ȯ���� �ƴϸ� ����

        // ���õ� ��ü�� MeshRenderer ������Ʈ�� �ִ��� Ȯ��
        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            // MeshRenderer�� �����ϸ� ù ��° Shared Material ��������
            Material sharedMaterial = meshRenderer.sharedMaterial;

            // Shared Material �̸� ���� "fade"�� ���ԵǾ� �ִ��� Ȯ��
            if (sharedMaterial.name.ToLower().EndsWith("fade"))
            {
                Debug.Log("Selected object's Shared Material contains 'fade' in its name.");
            }
            else
            {
                // ���õ� ��ü�� Shared Material �̸��� "_fade" �߰��� Material�� �ִ��� �˻�
                string newMaterialName = sharedMaterial.name + "_fade";
                Material newMaterial = FindMaterialInScene(newMaterialName);

                if (newMaterial != null)
                {
                    meshRenderer.material = newMaterial;
                    Debug.Log("Assigned new 'fade' Material to the selected object.");
                }
                else
                {
                    
                    Debug.Log(newMaterialName +"No 'fade' Material found for the selected object.");
                }
            }
        }
        else
        {
            Debug.Log("Selected object does not have a MeshRenderer.");
        }
    
}

    // ������ �̸��� �´� Material�� �˻��ϴ� �Լ�
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
