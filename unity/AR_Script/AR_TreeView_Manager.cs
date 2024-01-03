using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEditor.IMGUI.Controls;

public class AR_TreeView_Manager
{
    // (기본설정) 트리 뷰
    private TreeViewState treeViewState;
    private AR_ObjectTreeView treeView;

    // 목록에 보이는 오브젝트
    private LinkedList<GameObject> containedObjects = new LinkedList<GameObject>();
    // 목록에 보이는 오브젝트, 빠른 자료검색용 HashTable
    private HashSet<GameObject> hashObjects = new HashSet<GameObject>();
    // 드래그 앤 드롭된 오브젝트
    private LinkedList<GameObject> draggedObjects = new LinkedList<GameObject>();

    private MultiColumnHeaderState.Column multiColumHeaderState;

    public string treeView_name;

    public AR_TreeView_Manager(string treeView_name = "트리뷰 목록")
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

    // 제일 처음해주는 초기화
    private void Initialize()
    {
        // TreeViewState 및 MultiColumnHeaderState 초기화
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

        // TreeView 초기화
        var multiColumnHeader = new MultiColumnHeader(headerState);
        treeView = new AR_ObjectTreeView(treeViewState, multiColumnHeader, containedObjects);
        treeView.UpdateDraggedObjects(containedObjects);
    }

    public bool delete_Selected_Object()
    {
        var iList = treeView.GetSelection();

        // 삭제대상에 포커스가 맞춰져 있지 않으면 종료
        if (!treeView.HasFocus()) return false;

        // 선택된 것이 없다면 종료
        if (iList.Count == 0) return false;

        // 셋이아니라 헤쉬테이블로, key에 GetInstanceID()
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
    /// 오브젝트를 리스트에 삽입한다.
    /// </summary>
    /// true 이벤트 사용함
    /// false 이벤트 사용안함
    /// <param name="currentEvent"></param>
    public bool insert_Object_In_List(Event currentEvent)
    {
        // 트리뷰 범위안에 마우스가 없다면 종료
        if (!treeView.TreeViewRect.Contains(currentEvent.mousePosition)) return false;

        // 아이콘 이동할때 나오는 마우스 모양
        DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

        // 드래그 중이면 이벤트 소모 후 종료, 드래그한 마우스를 놓으면 진행
        if (currentEvent.type == EventType.DragUpdated)
        {
            return true;
        }

        // 드래그 앤 드롭 작업 수락
        DragAndDrop.AcceptDrag();

        // 드래그 된 오브젝트 목록을 링크드 리스트에 저장
        draggedObjects = new LinkedList<GameObject>(DragAndDrop.objectReferences.OfType<GameObject>());

        // 중복 리스트를 제거한다.
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

        // 최종리스트에 추가한다.
        foreach (var value in draggedObjects)
        {
            containedObjects.AddLast(value);
        }
        treeView.UpdateDraggedObjects(containedObjects);

        return true;
    }

    /// <summary>
    /// 드래그 앤 드롭 처리
    /// </summary>
    private void input_Mouse(Event currentEvent)
    {
        // 마우스 확인
        switch (currentEvent.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                if (insert_Object_In_List(currentEvent)) break;
                return;
            default:
                return;
        }
        // 위에서 마우스 관련 처리를 한 경우에만 여기로 온다.
        // 마우스 관련 처리를 했으므로 이벤트를 소모한다.
        currentEvent.Use();
    }

    private void input_Keyboard(Event currentEvent)
    {
        // 키보드가 눌린 것이 없다면 종료.
        if (currentEvent.type != EventType.KeyDown) return;

        // 키보드 확인
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
        // 위에서 키보드 관련 처리를 한 경우에만 여기로 온다.
        // 키보드 관련 처리를 했으므로 이벤트를 소모한다.
        currentEvent.Use();
    }

    public void OnGUI(Rect treeViewRect)
    {
        Event currentEvent = Event.current;

        // 마우스 입력 처리
        input_Mouse(currentEvent);

        // 키 입력 처리
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
/// 리스트 박스 형태 GUI를 구현하기 위해 필요한 클래스
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
        // TreeView에 드래그된 오브젝트를 추가
        foreach (var obj in containedObjects)
        {
            id++;
            allItems.Add(new TreeViewItem { id = id, depth = -1, displayName = obj.name });
        }
        SetupParentsAndChildrenFromDepths(root, allItems);
        return root;
    }
}