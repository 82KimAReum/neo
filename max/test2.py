# import pymxs
# rt = pymxs.runtime

# # 현재 씬에서 모든 노드(오브젝트) 선택
# selected_nodes = rt.selection

# # 선택한 노드들을 그룹으로 묶기
# if len(selected_nodes) > 0:
#     # 새로운 빈 그룹 생성
#     new_group = rt.group()
    
#     # 선택한 모든 노드를 새로운 그룹에 추가
#     for node in selected_nodes:
#         rt.addNodeToGroup(new_group, node)
# else:
#     print("선택한 노드가 없습니다.")

import pymxs

def group_selected_objects():
    # Get a reference to the MaxScript runtime
    rt = pymxs.runtime

    # Get a list of all selected objects
    selected_objects = rt.selection

    # Check if there are any selected objects
    if len(selected_objects) == 0:
        print("No objects selected.")
        return

    # Create a new group
    new_group = rt.group()

    # Add selected objects to the group
    for obj in selected_objects:
        new_group.append(obj)

    print("Selected objects grouped successfully.")

# Call the function to group selected objects
group_selected_objects()