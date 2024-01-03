import bpy

def find_duplicate_selected_vertices(mesh, selected_indices):
    duplicate_vertices = {}
    for i in selected_indices:
        vert = mesh.vertices[i]
        key = (round(vert.co.x, 6), round(vert.co.y, 6))
        if key not in duplicate_vertices:
            duplicate_vertices[key] = []
        duplicate_vertices[key].append(i)
    return {k: v for k, v in duplicate_vertices.items() if len(v) > 1}

def move_to_highest_z(mesh, vertices):
    z_values = [mesh.vertices[i].co.z for i in vertices]
    max_z_index = vertices[z_values.index(max(z_values))]

    target_z = mesh.vertices[max_z_index].co.z

    for i in vertices:
        mesh.vertices[i].co.z = target_z

def main():
    # 현재 활성화된 객체 가져오기
    obj = bpy.context.active_object
    if obj is None or obj.type != 'MESH':
        print("현재 활성화된 객체가 유효한 메쉬 객체가 아닙니다.")
        return

    mesh = obj.data

    # 선택된 정점 인덱스 가져오기
    selected_indices = [i.index for i in bpy.context.active_object.data.vertices if i.select]

    if not selected_indices:
        print("선택된 정점이 없습니다.")
        return

    duplicate_vertex_groups = find_duplicate_selected_vertices(mesh, selected_indices)

    for vertices in duplicate_vertex_groups.values():
        move_to_highest_z(mesh, vertices)

    print("선택된 정점 내에서 정점 이동이 완료되었습니다.")

# 스크립트 실행
main()
