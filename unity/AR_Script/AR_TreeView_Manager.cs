using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEditor.IMGUI.Controls;

public class AR_TreeView_Manager
{
    // (�⺻����) Ʈ�� ��
    private TreeViewState treeViewState;
    private AR_ObjectTreeView treeView;

    // ��Ͽ� ���̴� ������Ʈ
    private LinkedList<GameObject> containedObjects = new LinkedList<GameObject>();
    // ��Ͽ� ���̴� ������Ʈ, ���� �ڷ�˻��� HashTable
    private HashSet<GameObject> hashObjects = new HashSet<GameObject>();
    // �巡�� �� ��ӵ� ������Ʈ
    private LinkedList<GameObject> draggedObjects = new LinkedList<GameObject>();

    private MultiColumnHeaderState.Column multiColumHeaderState;

    public string treeView_name;

    public AR_TreeView_Manager(string treeView_name = "Ʈ���� ���")
    {
        this.treeView_name = treeView_name;
        Initialize();
    }

    public LinkedList<GameObject> ObjectList
    {
        get
        {
            return containedObjects;
        }
    }

    // ���� ó�����ִ� �ʱ�ȭ
    private void Initialize()
    {
        // TreeViewState �� MultiColumnHeaderState �ʱ�ȭ
        if (treeViewState == null)
            treeViewState = new TreeViewState();

        multiColumHeaderState = new MultiColumnHeaderState.Column
        {
            headerContent = new GUIContent(treeView_name),
            headerTextAlignment = TextAlignment.Center,
            sortedAscending = true,
            sortingArrowAlignment = TextAlignment.Right,
            width = 200,
            minWidth = 150,
            autoResize = false,
            allowToggleVisibility = false
        };


        var headerState = new MultiColumnHeaderState(new[] {multiColumHeaderState});

        // TreeView �ʱ�ȭ
        var multiColumnHeader = new MultiColumnHeader(headerState);
        treeView = new AR_ObjectTreeView(treeViewState, multiColumnHeader, containedObjects);
        treeView.UpdateDraggedObjects(containedObjects);
    }

    public bool delete_Selected_Object()
    {
        var iList = treeView.GetSelection();

        // ������� ��Ŀ���� ������ ���� ������ ����
        if (!treeView.HasFocus()) return false;

        // ���õ� ���� ���ٸ� ����
        if (iList.Count == 0) return false;

        // ���̾ƴ϶� �콬���̺��, key�� GetInstanceID()
        LinkedListNode<GameObject> currentNode = containedObjects.First;
        int index_LL = 1;
        int index_iL = 0;
        while (currentNode != null && index_iL < iList.Count)
        {
            if (iList[index_iL] != index_LL)
            {
                index_LL++;
                currentNode = currentNode.Next;
            }

            else
            {
                LinkedListNode<GameObject> nextNode = currentNode.Next;
                hashObjects.Remove(currentNode.Value);
                containedObjects.Remove(currentNode);
                currentNode = nextNode;
                index_iL++;
                index_LL++;
            }
        }
        treeView.UpdateDraggedObjects(containedObjects);
        return true;
    }

    /// <summary>
    /// ������Ʈ�� ����Ʈ�� �����Ѵ�.
    /// </summary>
    /// true �̺�Ʈ �����
    /// false �̺�Ʈ ������
    /// <param name="currentEvent"></param>
    public bool insert_Object_In_List(Event currentEvent)
    {
        // Ʈ���� �����ȿ� ���콺�� ���ٸ� ����
        if (!treeView.TreeViewRect.Contains(currentEvent.mousePosition)) return false;

        // ������ �̵��Ҷ� ������ ���콺 ���
        DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

        // �巡�� ���̸� �̺�Ʈ �Ҹ� �� ����, �巡���� ���콺�� ������ ����
        if (currentEvent.type == EventType.DragUpdated)
        {
            return true;
        }

        // �巡�� �� ��� �۾� ����
        DragAndDrop.AcceptDrag();

        // �巡�� �� ������Ʈ ����� ��ũ�� ����Ʈ�� ����
        draggedObjects = new LinkedList<GameObject>(DragAndDrop.objectReferences.OfType<GameObject>());

        // �ߺ� ����Ʈ�� �����Ѵ�.
        LinkedListNode<GameObject> currentNode = draggedObjects.First;

        while (currentNode != null)
        {
            if (hashObjects.Contains(currentNode.Value))
            {
                LinkedListNode<GameObject> nextNode = currentNode.Next;
                draggedObjects.Remove(currentNode);
                currentNode = nextNode;
            }
            else
            {
                hashObjects.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        // ��������Ʈ�� �߰��Ѵ�.
        foreach (var value in draggedObjects)
        {
            containedObjects.AddLast(value);
        }
        treeView.UpdateDraggedObjects(containedObjects);

        return true;
    }

    /// <summary>
    /// �巡�� �� ��� ó��
    /// </summary>
    private void input_Mouse(Event currentEvent)
    {
        // ���콺 Ȯ��
        switch (currentEvent.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                if (insert_Object_In_List(currentEvent)) break;
                return;
            default:
                return;
        }
        // ������ ���콺 ���� ó���� �� ��쿡�� ����� �´�.
        // ���콺 ���� ó���� �����Ƿ� �̺�Ʈ�� �Ҹ��Ѵ�.
        currentEvent.Use();
    }

    private void input_Keyboard(Event currentEvent)
    {
        // Ű���尡 ���� ���� ���ٸ� ����.
        if (currentEvent.type != EventType.KeyDown) return;

        // Ű���� Ȯ��
        switch (currentEvent.keyCode)
        {
            case KeyCode.Delete:
                if (delete_Selected_Object()) break;
                return;
            case KeyCode.A:
                if (!treeView.TreeViewRect.Contains(currentEvent.mousePosition)) return;
                Debug.Log(treeView.TreeViewRect);
                break;
            default:
                return;
        }
        // ������ Ű���� ���� ó���� �� ��쿡�� ����� �´�.
        // Ű���� ���� ó���� �����Ƿ� �̺�Ʈ�� �Ҹ��Ѵ�.
        currentEvent.Use();
    }

    public void OnGUI(Rect treeViewRect)
    {
        Event currentEvent = Event.current;

        // ���콺 �Է� ó��
        input_Mouse(currentEvent);

        // Ű �Է� ó��
        input_Keyboard(currentEvent);

        using (var areaScope = new GUILayout.AreaScope(treeViewRect))
        {
            Rect tmpRect = new Rect(0, 0, treeViewRect.width, treeViewRect.height);
            multiColumHeaderState.width = treeViewRect.width - 2;
            treeView.OnGUI(tmpRect);
        }
    }
}



/// <summary>
/// ����Ʈ �ڽ� ���� GUI�� �����ϱ� ���� �ʿ��� Ŭ����
/// </summary>
public class AR_ObjectTreeView : TreeView
{
    private LinkedList<GameObject> containedObjects;

    public Rect TreeViewRect
    {
        get
        {
            return this.treeViewRect;
        }
    }

    public AR_ObjectTreeView(TreeViewState state, MultiColumnHeader multiColumnHeader, LinkedList<GameObject> containedObjects)
    : base(state, multiColumnHeader)
    {
        this.containedObjects = containedObjects;
        showBorder = true;
    }
    
    public void UpdateDraggedObjects(LinkedList<GameObject> containedObjects)
    {
        this.containedObjects = containedObjects;
        Reload();
    }

    protected override TreeViewItem BuildRoot()
    {
        int id = 0;
        var root = new TreeViewItem { id = id, depth = -1, displayName = "Root" };
        var allItems = new List<TreeViewItem>();
        // TreeView�� �巡�׵� ������Ʈ�� �߰�
        foreach (var obj in containedObjects)
        {
            id++;
            allItems.Add(new TreeViewItem { id = id, depth = -1, displayName = obj.name });
        }
        SetupParentsAndChildrenFromDepths(root, allItems);
        return root;
    }
}