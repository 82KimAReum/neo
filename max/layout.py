


--한곳에 모여있는 오브젝트들 옆으로 펼쳐놓는 스크립트입니다. 
--묶여있는 오브젝트는 제외하고 사용할것!


fn layoutObjectsWithBoundingBoxes objs =
(
    local prevWidth = 0.0
    for obj in objs do
    (
        local bbMin = obj.min
        local bbMax = obj.max
        local width = bbMax.x - bbMin.x
        
        if prevWidth != 0.0 do
        (
            obj.position.x = prevWidth + width
        )
        
        prevWidth = obj.position.x + width/2
    )
)

-- 현재 선택된 모든 오브젝트를 가져옴
selectedObjects = selection as array
-- 배열을 X 축 기준으로 정렬
--sort selectedObjects by (selectedObjects[1].min.x)

-- 첫 번째 오브젝트의 위치를 (0, 0, 0)으로 설정
if selectedObjects.count > 0 do
    --selectedObjects[1].position = [0, 0, 0]

-- 선택한 오브젝트들을 나열하여 배치
layoutObjectsWithBoundingBoxes selectedObjects






--=================================================\
--한곳에 모여있는 오브젝트들 옆으로 펼쳐놓는 스크립트입니다. 
--묶여있는 오브젝트는 제외하고 사용할것!





-- 현재 선택된 객체를 가져옵니다.
 --selectedObj = selection[1]
fn checkParent objs=
if isvalidnode(objs) then
(
    -- 부모 객체가 있는지 확인합니다.
    local parentObj = objs.parent

    if isvalidnode(objs) then
    (
        format "선택한 객체의 부모: %\n" parentObj.name
        parentObj
    )
    else
    (
        format "선택한 객체에 부모가 없습니다.\n"
    )
)
else
(
    format "유효한 객체가 선택되지 않았습니다.\n"
)



fn layoutObjectsWithBoundingBoxes objs =
(
    
    local prevWidth = 0.0
    for obj in objs do
    (
        local bbMin = obj.min
        local bbMax = obj.max
        local width = bbMax.x - bbMin.x
        
        if prevWidth != 0.0 and checkParent (objs) ==false do
        (
            obj.position.x = prevWidth + width
        )
        
        prevWidth = obj.position.x + width/2
    )
)



-- 현재 선택된 모든 오브젝트를 가져옴
selectedObjects = selection as array
-- 배열을 X 축 기준으로 정렬
--sort selectedObjects by (selectedObjects[1].min.x)

-- 첫 번째 오브젝트의 위치를 (0, 0, 0)으로 설정
if selectedObjects.count > 0 do
    --selectedObjects[1].position = [0, 0, 0]

-- 선택한 오브젝트들을 나열하여 배치
layoutObjectsWithBoundingBoxes selectedObjects




--=================================================\


--한곳에 모여있는 오브젝트들 옆으로 펼쳐놓는 스크립트입니다. 
--묶여있는 오브젝트는 제외하고 사용할것!






fn layoutObjectsWithBoundingBoxes objs =
(
    
    local prevWidth = 0.0
    for obj in objs do
    (
        local bbMin = obj.min
        local bbMax = obj.max
        local width = bbMax.x - bbMin.x
        --print checkParent (objs)
        if prevWidth != 0.0 and checkParent (objs) ==0 do
        (--print "hi"
            obj.position.x = prevWidth + width
			prevWidth = obj.position.x + width/2
        )
        
        --prevWidth = obj.position.x + width/2
    )
)



-- 현재 선택된 객체를 가져옵니다.
 --selectedObj = selection[1]
fn checkParent objs=
if isvalidnode(objs) then
(print "0"
    -- 부모 객체가 있는지 확인합니다.
    local parentObj = objs.parent

    if isvalidnode(objs) then
    (print "1"
        format "선택한 객체의 부모: %\n" parentObj.name
        --parentObj
		return 1
    )
    else
    (print "2"
        format "선택한 객체에 부모가 없습니다.\n"
		return 0
    )
)
else
(print "3"
    format "유효한 객체가 선택되지 않았습니다.\n"
	return 0
)


-- 현재 선택된 모든 오브젝트를 가져옴
selectedObjects = selection as array
-- 배열을 X 축 기준으로 정렬
--sort selectedObjects by (selectedObjects[1].min.x)

-- 첫 번째 오브젝트의 위치를 (0, 0, 0)으로 설정
if selectedObjects.count > 0 do
    --selectedObjects[1].position = [0, 0, 0]

-- 선택한 오브젝트들을 나열하여 배치
layoutObjectsWithBoundingBoxes selectedObjects



--=============================



fn checkParent obj =
(
    if isvalidnode(obj) then
    (
        -- 부모 객체가 있는지 확인합니다.
        local parentObj = obj.parent

        if isvalidnode(parentObj) then
        (
            format "선택한 객체의 부모: %\n" parentObj.name
            1 -- 부모가 있음을 나타내는 값 반환
        )
        else
        (
            format "선택한 객체에 부모가 없습니다.\n"
            0 -- 부모가 없음을 나타내는 값 반환
        )
    )
    else
    (
        format "유효한 객체가 선택되지 않았습니다.\n"
        0 -- 부모가 없음을 나타내는 값 반환
    )
)

fn layoutObjectsWithBoundingBoxes objs =
(
    local prevWidth = 0.0
    for obj in objs where checkParent(obj) == 0 do -- 부모가 없는 경우에만 진행
    (
        local bbMin = obj.min
        local bbMax = obj.max
        local width = bbMax.x - bbMin.x
        
        obj.position.x = prevWidth + width
        prevWidth = obj.position.x + width / 2
    )
)

-- 현재 선택된 모든 오브젝트를 가져옴
selectedObjects = selection as array

-- 선택한 오브젝트들을 나열하여 배치
layoutObjectsWithBoundingBoxes selectedObjects


--=====================================================================================





--한곳에 모여있는 오브젝트들 옆으로 펼쳐놓는 스크립트입니다. 
fn checkParent obj =
(
    if isvalidnode(obj) then
    (
        -- 부모 객체가 있는지 확인합니다.
        local parentObj = obj.parent

        if isvalidnode(parentObj) then
        (
            format "선택한 객체의 부모: %\n" parentObj.name
            1 -- 부모가 있음을 나타내는 값 반환
        )
        else
        (
            format "선택한 객체에 부모가 없습니다.\n"
            0 -- 부모가 없음을 나타내는 값 반환
        )
    )
    else
    (
        format "유효한 객체가 선택되지 않았습니다.\n"
        0 -- 부모가 없음을 나타내는 값 반환
    )
)

fn layoutObjectsWithBoundingBoxes objs =
(
    local prevWidth = 0.0
    for obj in objs where checkParent(obj) == 0 do -- 부모가 없는 경우에만 진행
    (
        local bbMin = obj.min
        local bbMax = obj.max
        local width = bbMax.x - bbMin.x
        
		if prevWidth != 0.0  do
        (
            obj.position.x = prevWidth + width
			
        )
        prevWidth = obj.position.x + width
    )
)

-- 현재 선택된 모든 오브젝트를 가져옴
selectedObjects = selection as array

-- 선택한 오브젝트들을 나열하여 배치
layoutObjectsWithBoundingBoxes selectedObjects


-------------=============================================================================
-------------=============================================================================
-------------=============================================================================



--한곳에 모여있는 오브젝트들 옆으로 펼쳐놓는 스크립트입니다. 
--오브젝트를 선택한 상태에서 사용하세요

fn checkParent obj =
(
    if isvalidnode(obj) then
    (
        -- 부모 객체가 있는지 확인합니다.
        local parentObj = obj.parent

        if isvalidnode(parentObj) then
        (
            format "선택한 객체의 부모: %\n" parentObj.name
            1 -- 부모가 있음을 나타내는 값 반환
        )
        else
        (
            format "선택한 객체에 부모가 없습니다.\n"
            0 -- 부모가 없음을 나타내는 값 반환
        )
    )
    else
    (
        format "유효한 객체가 선택되지 않았습니다.\n"
        0 -- 부모가 없음을 나타내는 값 반환
    )
)

fn layoutObjectsWithBoundingBoxes objs =
(
    local prevWidth = 0.0
    for obj in objs where checkParent(obj) == 0 do -- 부모가 없는 경우에만 진행
    (
        local bbMin = obj.min
        local bbMax = obj.max
        local width = bbMax.x - bbMin.x
		
		if width<1 do 
		(
			local width = bbMax.y - bbMin.y
			
		)
			if prevWidth != 0.0  do
		(
			obj.position.x = prevWidth + width
			
		)
		prevWidth = obj.position.x + width
		
        
		
    )
)

-- 현재 선택된 모든 오브젝트를 가져옴
selectedObjects = selection as array

-- 선택한 오브젝트들을 나열하여 배치
layoutObjectsWithBoundingBoxes selectedObjects
