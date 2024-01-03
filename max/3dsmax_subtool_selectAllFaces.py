import pymxs
from pymxs import runtime as rt

# Get the currently selected object
selected_obj = rt.selection[0]
print (selected_obj)

# 폴리곤 선택 도구로 변경합니다.
rt.subObjectLevel = 4

# Check if the selected object is an Editable Poly
if rt.isKindOf(selected_obj, rt.Editable_Poly):
    # Get the number of faces in the Editable Poly

    # 선택한 폴리곤이 가진 면의 갯수를 모두 계산합니다
    num_faces = rt.polyOp.getNumFaces(selected_obj)
    
    # face의 정보를 담을 수있는 num_faces크기 만큼의 배열을 생성합니다.
    face_selection = rt.bitarray(num_faces)

    # face가 여러개 선택될 수 있도록 허용합니다.
    for i in range(num_faces):
        face_selection[i] = True
    
    # 선택된 오브젝트(selected_obj)에서 면의 갯수(face_selection)만큼 선택합니다.
    rt.polyOp.setFaceSelection(selected_obj, face_selection)

    print("All faces of the selected Editable Poly are now selected.")

else:
    print("No valid Editable Poly object is selected.")


# 1. 여러 작업이 필요한 경우 분할해서 명령하자.
#     1-1 모든 면 선택을 하라고 명령했지만 기본은 면선택 모드가 아님
#      -> 면선택 명령을 먼저 앞에 삽입하기.
#      ex) gpt에서 면을 선택하는 코드는 제공 했지만, Selection이 선택되지 않아 아무 반응이 없었다.

# 2. 오류가 발생하는 줄은 그대로 복사해서 gpt에 다시 물어보자.
#     2-1 max script를 python 코드로 제대로 변환해 주지 않아 발생한 문제가 많음.
#     ex) selected_obj = rt.selection[1]에서 맥스스크립트는 인덱스가 1부터 시작하지만, 파이썬은 0부터 시작한다.

# 3. 3ds 맥스의 기본 내장함수는 대부분 rt.@@@로 시작한다.
#     3-1 3ds의 명령어가 rt.@@@으로 시작하지 않고 오류가 발생한다면 gpt에 다시 물어보자.
#     ex) if rt.isKindOf(selected_obj, Editable_Poly):에서
#         Editable_Poly는 3ds의 라이브러리이다. 따라서 rt.Editable_Poly가 옳은 표현이다.


# 4. 아무리 오류코드를 집어 넣어도 해결 안되는 경우.
#     4-1 New chat을 통해 새로 명령해 보자.
#      -> 사용중인 프롬프트의 모든 대화 내용을 기반으로 명령이 새로운 명령이 작성 됨. 비슷한 문장을 아무리 쳐도 같은 답변 밖에 받지 못한다.
