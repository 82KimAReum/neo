맥스에서 python.ExecuteFile "D:/ar/test2.py" 



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


#     -- 모든 객체 선택
# select objects

# -- 선택된 객체들을 그룹으로 묶기
# group nodes:selection name:"MyGroup"

# -- 그룹 열기
# local myGroup = $MyGroup
# myGroup.open = true

# -- 색상이 "d8c75c"인 그룹 선택
# for obj in myGroup do
# (
#     if obj.wirecolor == color 195 50 130 do
#     (
#         selectMore obj
#     )
# )







# -- 모든 오브젝트 선택
# select objects

# -- 선택된 오브젝트들을 그룹으로 묶음

# var1 =actionMan.executeAction 0 "40140"   -- Groups: Group

# actionMan.executeAction 0 "40142"  -- Groups: Group Open

# select $Box002

# $.pivot = $Box001.position





# select objects
# group selection name:"boxes"
# setGroupOpen $boxes true -- 그룹오픈
# $boxes.pivot = $Box001.pivot --분홍색 그룹 피봇 지형으로맞추기

# $boxes.x_scale  -5.5
# $boxes.y_scale  5.0
# $boxes.z_scale  5.0

-- 모든 노드들을 검색하여 이름에 "Ground"가 포함된 오브젝트들을 선택합니다.
fn findObjectsWithGroundName =
(
    local objList = #()
    
    -- 모든 노드들을 순회하며 이름에 "Ground"가 포함되어 있는지 확인합니다.
    for obj in objects do
    (
        if findString obj.name "Ground" == true then
        (
			print obj.name
            append objList obj
        )
    )
    
    -- 선택된 오브젝트들을 반환합니다.

    select objList
)

-- 함수를 호출하여 이름에 "Ground"가 포함된 오브젝트들을 선택합니다.
findObjectsWithGroundName()





select objects
group selection name:"Group001"
setGroupOpen $Group001 true -- 그룹오픈
$Group001.pivot = $gl_cas01_Ground.pivot --그룹 피봇 지형으로맞추기 !

--스케일 -5,5,5
localScaleMatrix = scaleMatrix [-5,5,5]
$Group001.transform *= localScaleMatrix

--포지션 영점 조정
$Group001.position =[0,0,0]
setGroupOpen $Group001 false-- 그룹닫기
explodeGroup $Group001

--ResetXForm
select $gl_cas01_Ground --지형만 선택 !
macros.run "PolyTools" "ResetXForm" 

--에디터블 폴리 변환
macros.run "Modifier Stack" "Convert_to_Poly"

--모든 면선택
# subobjectLevel = 4
# actionMan.executeAction 0 "40021"
--플립
$.EditablePoly.flipNormals 1

--노말 면선택후 리셋 유니파이
subobjectLevel = 0
modPanel.setCurrentObject $.baseObject
modPanel.addModToSelection (Edit_Normals ()) ui:on
$.modifiers[#Edit_Normals].selectBy = 3
actionMan.executeAction 0 "40021"
$.modifiers[#Edit_Normals].EditNormalsMod.Reset ()
$.modifiers[#Edit_Normals].EditNormalsMod.Unify ()
subobjectLevel = 0
modPanel.setCurrentObject $.modifiers[#Edit_Normals]
maxOps.CollapseNode $ off  --컬랩스


--원본
# subobjectLevel = 0 
# modPanel.setCurrentObject $.baseObject
# modPanel.addModToSelection (Edit_Normals ()) ui:on
# $.modifiers[#Edit_Normals].selectBy = 3
# actionMan.executeAction 0 "40021"
# $.modifiers[#Edit_Normals].EditNormalsMod.SetSelection #{1..157643}
# $.modifiers[#Edit_Normals].EditNormalsMod.Unify ()
# subobjectLevel = 0
# maxOps.CollapseNode $ off



select objects
group selection name:"Group001"
setGroupOpen $Group001 true -- 그룹오픈
$Group001.pivot = $gl_cas01_Ground.pivot --그룹 피봇 지형으로맞추기 !

--익스포트 alt-f-e-e
--(지역명)_(필드명)_Original.fbx 



-------------------------------------------------------------------

select objects
group selection name:"Group001"
setGroupOpen $Group001 true -- 그룹오픈

-- 모든 노드들을 검색하여 이름에 "Ground"가 포함된 오브젝트들을 선택합니다.
fn findObjectsWithGroundName =
(
    local objList = #()
    
    -- 모든 노드들을 순회하며 이름에 "Ground"가 포함되어 있는지 확인합니다.
    for obj in $Group001 do
    (
        if findString obj.name "Ground" == true then
        (
			print obj.name
            append objList obj
        )
    )
    
    -- 선택된 오브젝트들을 반환합니다.

    --select objList
	objList
)
-- 함수를 호출하여 이름에 "Ground"가 포함된 오브젝트들을 가져옵니다.
foundObjects = findObjectsWithGroundName()

-- 찾은 오브젝트의 개수를 확인하고 필요한 작업을 수행합니다.
if foundObjects.count == 1 then
(
    -- 오브젝트가 1개인 경우의 작업을 여기에 추가합니다.
    format "찾은 오브젝트의 개수: 1\n"
    format "오브젝트 이름: %\n" foundObjects[1].name

	select foundObjects[1]
	ver_ground=$
		
	$Group001.pivot = ver_ground.pivot --그룹 피봇 지형으로맞추기 !

	
	--스케일 -5,5,5
	localScaleMatrix = scaleMatrix [-5,5,5]
	$Group001.transform *= localScaleMatrix

	--포지션 영점 조정
	$Group001.position =[0,0,0]
	setGroupOpen $Group001 false-- 그룹닫기
	explodeGroup $Group001

	--ResetXForm
	select foundObjects --지형만 선택 !
	macros.run "PolyTools" "ResetXForm" 

	--에디터블 폴리 변환
	macros.run "Modifier Stack" "Convert_to_Poly"

	--모든 면선택
	--subobjectLevel = 4
	-- actionMan.executeAction 0 "40021"
	--플립
	$.EditablePoly.flipNormals 1

	--노말 면선택후 리셋 유니파이
	subobjectLevel = 0
	modPanel.setCurrentObject $.baseObject
	modPanel.addModToSelection (Edit_Normals ()) ui:on
	$.modifiers[#Edit_Normals].selectBy = 3
	actionMan.executeAction 0 "40021"
	$.modifiers[#Edit_Normals].EditNormalsMod.Reset ()
	$.modifiers[#Edit_Normals].EditNormalsMod.Unify ()
	subobjectLevel = 0
	modPanel.setCurrentObject $.modifiers[#Edit_Normals]
	maxOps.CollapseNode $ off  --컬랩스



	--select objects
	--group selection name:"Group001"
	--setGroupOpen $Group001 true -- 그룹오픈
	--$Group001.pivot = $gl_cas01_Ground.pivot --그룹 피봇 지형으로맞추기 !

	--익스포트 alt-f-e-e
	--(지역명)_(필드명)_Original.fbx 

		
	
)
else if foundObjects.count > 1 then
(
    -- 오브젝트가 1개보다 많은 경우의 작업을 여기에 추가합니다.
    format "찾은 오브젝트의 개수 초과: %\n" foundObjects.count
)
else
(
    -- 오브젝트를 찾지 못한 경우의 작업을 여기에 추가합니다.
    format "오브젝트를 찾지 못했습니다.\n"
)





















===========================================================================




select objects
group selection name:"Group001"
setGroupOpen $Group001 true -- 그룹오픈

-- 모든 노드들을 검색하여 이름에 "Ground"가 포함된 오브젝트들을 선택합니다.
fn findObjectsWithGroundName =
(
    local objList = #()
    
    -- 모든 노드들을 순회하며 이름에 "Ground"가 포함되어 있는지 확인합니다.
    for obj in $Group001 do
    (
        if findString obj.name "Ground" == true then
        (
			print obj.name
            append objList obj
        )
    )
    
    -- 선택된 오브젝트들을 반환합니다.

    --select objList
	objList
)
-- 함수를 호출하여 이름에 "Ground"가 포함된 오브젝트들을 가져옵니다.
foundObjects = findObjectsWithGroundName()

-- 찾은 오브젝트의 개수를 확인하고 필요한 작업을 수행합니다.
if foundObjects.count == 1 then
(
    -- 오브젝트가 1개인 경우의 작업을 여기에 추가합니다.
    format "찾은 오브젝트의 개수: 1\n"
    format "오브젝트 이름: %\n" foundObjects[1].name

	select foundObjects[1]
	ver_ground=$
		
	$Group001.pivot = ver_ground.pivot --그룹 피봇 지형으로맞추기 !

	
	--스케일 -5,5,5
	localScaleMatrix = scaleMatrix [-5,5,5]
	$Group001.transform *= localScaleMatrix

	--포지션 영점 조정
	$Group001.position =[0,0,0]
	setGroupOpen $Group001 false-- 그룹닫기
	explodeGroup $Group001

	--ResetXForm
	select foundObjects --지형만 선택 !
	macros.run "PolyTools" "ResetXForm" 

	--에디터블 폴리 변환
	macros.run "Modifier Stack" "Convert_to_Poly"

	--모든 면선택
	--subobjectLevel = 4
	-- actionMan.executeAction 0 "40021"
	--플립
	$.EditablePoly.flipNormals 1

	--노말 면선택후 리셋 유니파이
	subobjectLevel = 0
	modPanel.setCurrentObject $.baseObject
	modPanel.addModToSelection (Edit_Normals ()) ui:on
	$.modifiers[#Edit_Normals].selectBy = 3
	actionMan.executeAction 0 "40021"
	$.modifiers[#Edit_Normals].EditNormalsMod.Reset ()
	$.modifiers[#Edit_Normals].EditNormalsMod.Unify ()
	subobjectLevel = 0
	modPanel.setCurrentObject $.modifiers[#Edit_Normals]
	maxOps.CollapseNode $ off  --컬랩스



	select objects
	group selection name:"Group001"
	setGroupOpen $Group001 true -- 그룹오픈
	$Group001.pivot = ver_ground.pivot --그룹 피봇 지형으로맞추기 !


	--익스포트 alt-f-e-e
	--(지역명)_(필드명)_Original.fbx 

		
	
)
else if foundObjects.count > 1 then
(
    -- 오브젝트가 1개보다 많은 경우의 작업을 여기에 추가합니다.
    format "찾은 오브젝트의 개수 초과: %\n" foundObjects.count
)
else
(
    -- 오브젝트를 찾지 못한 경우의 작업을 여기에 추가합니다.
    format "오브젝트를 찾지 못했습니다.\n"
)