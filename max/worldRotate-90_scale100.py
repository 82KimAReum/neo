-- 선택한 오브젝트의 worldRotation-90,0,0,그리고 스케일 100으로   설정하는 함수
fn setWorldRotation obj rotation =
(
    objTM = obj.transform
    objTM.rotation = rotation as quat
    obj.transform = objTM
)

-- 선택된 오브젝트들을 가져옴
selectedObjects = selection

localScaleMatrix = scaleMatrix [1,1,1]
-- 선택된 각 오브젝트에 대해 worldRotation 설정 함수 호출
for obj in selectedObjects do
(
	obj.transform = localScaleMatrix
    -- Y 축 주위로 45도 회전된 상태로 설정
    setWorldRotation obj (eulerangles -90 0 0)
	
)

-- 결과 메시지 출력
format "선택한 % 개의 오브젝트의 worldRotation을 설정했습니다." selectedObjects.count





--======================================================



-- 회전-90,0,0 스케일 100,100,100으로 변경하는 스크립트.
-- 변경할 오브젝트들을 선택한 상택에서 사용할것 !


-- 선택한 오브젝트의 worldRotation을 설정하는 함수
fn setWorldRotation obj rotation =
(
    objTM = obj.transform
    objTM.rotation = rotation as quat
    obj.transform = objTM
)

-- 선택된 오브젝트들을 가져옴
selectedObjects = selection

-- 선택된 각 오브젝트에 대해 worldRotation 설정 함수 호출
for obj in selectedObjects do
(
    -- 현재 위치와 스케일을 유지한 채 Y 축 주위로 90도 회전된 상태로 설정
    originalPos = obj.position
    --originalScale = obj.scale
    originalScale =   [1,1,1]
    setWorldRotation obj (eulerangles -90 0 0)
    obj.position = originalPos
    obj.scale = originalScale
)

-- 결과 메시지 출력
format "선택한 % 개의 오브젝트의 worldRotation을 설정했습니다." selectedObjects.count