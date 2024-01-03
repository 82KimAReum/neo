using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.IMGUI.Controls;

public class MyCustomEditor : EditorWindow
{
    private AR_Toolbar_Manager toolbar_Manager;
    private AR_TreeView_Manager treeView_Manager;

    /// <summary>
    /// (�⺻�Լ�) â�� ���� ȣ��Ǵ� �Լ� 
    /// </summary>
    [MenuItem("Tools/AR/AR Ŀ���� ������")]
    public static void ShowMyEditor()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("Made by AR");

        // â�� ũ��
        wnd.minSize = new Vector2(450, 200);
        wnd.maxSize = new Vector2(1920, 720);
    }

    /// <summary>
    /// (�⺻�Լ�) â�� ���� ȣ��Ǵ� �Լ� 
    /// </summary>
    private void OnEnable()
    {
        // Ʈ���並 �����Ѵ�.
        treeView_Manager = new AR_TreeView_Manager("Ʈ������ ���");

        // ���� ������ ���.
        AR_Left_Area.treeView_Manager = treeView_Manager;

        // ���ٸ� �����Ѵ�.
        string[] toolbar_names = {"toolbar1", "toolbar2", "toolbar3", "�� �Լ�", "���̵� �ݶ��̴�", "�ִ�"};
        AR_Toolbar[] toolbars = {
            new AR_Toolbar_1(),
            new AR_Toolbar_2(),
            new AR_Toolbar_3(),
            new myfunc(),
            new AR_Make_Fade_Collider_In_Toolbar(),
            new AR_Animation_aply()
        };
        toolbar_Manager = new AR_Toolbar_Manager(toolbar_names, toolbars);
    }

    /// <summary>
    /// (�⺻ �Լ�)�̺�Ʈ�� �߻��� ������ ȣ��ȴ�.
    /// </summary>
    private void OnGUI()
    {
        // Ʈ�� �� ǥ�� (���� ȭ��)
        Rect treeViewRect = new Rect(6, 11, Screen.width * 0.4f, Screen.height - 35);
        treeView_Manager.OnGUI(treeViewRect);

        // ���� ȭ�� (������ ȭ��)
        Rect toolBarRect = new Rect(Screen.width * 0.4f + 20, 11, Screen.width - (Screen.width * 0.4f + 20) - 11, Screen.height - 35);
        toolbar_Manager.OnGUI(toolBarRect);
    }
}

// �׳� ���� ������
static class AR_Left_Area
{
    static public AR_TreeView_Manager treeView_Manager;
}