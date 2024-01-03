-- 현재 선택된 오브젝트를 가져옵니다.
 selectedObjects = selection as array

-- 각각의 오브젝트에 대해 반복합니다.
for obj in selectedObjects do
(
    -- 오브젝트가 Editable Poly인지 확인합니다.
    if isKindOf obj Editable_Poly then
    (
        local polyObj = obj as Editable_Poly
        local numElements = numElements polyObj -- 엘리먼트의 개수를 가져옵니다.

        -- 엘리먼트를 개별 메시로 디테치합니다.
        for i = 1 to numElements do
        (
            polyOp.detach polyObj #{i} asNode:true
        )
    )
    else
    (
        print("선택된 오브젝트 중에 Editable Poly가 아닌 것이 있습니다.")
    )
)