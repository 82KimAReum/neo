subobjectLevel = 2-- 현재 선택된 객체를 얻어옴
obj = selection[1]

-- 객체가 선택되어 있는지 확인
if obj != undefined then
(
    -- Unwrap UVW Modifier를 얻어옴
    unwrapMod = modPanel.getCurrentObject()

    -- Unwrap UVW Modifier가 있는지 확인
    if isKindOf unwrapMod Unwrap_UVW then
    (
        -- 현재 선택된 엣지를 얻어옴
        selectedEdges = unwrapMod.getSelectedEdges()

        -- 선택된 엣지가 있는지 확인
        if selectedEdges != undefined and selectedEdges.count > 0 then
        (
            -- 첫 번째 선택된 엣지를 변수에 저장
            selectedEdge = selectedEdges[1] as string
			
            -- 선택된 엣지의 정보를 출력 (예: 인덱스)
            format "Selected Edge Index: %\n"  selectedEdges as string
			

			modPanel.addModToSelection (Edit_Poly ()) ui:on
			subobjectLevel = 2
			
			selectedEdgesAsBitArray = #{}
			for edge in selectedEdges do append selectedEdgesAsBitArray (edge as integer -4)
			

			--$.modifiers[#Edit_Poly].SetSelection #Edge selectedEdgesAsBitArray
			$.modifiers[#Edit_Poly].SetSelection #Edge #{}
			$.modifiers[#Edit_Poly].Select #Edge selectedEdgesAsBitArray
        )
        else
        (
            print "선택된 엣지가 없거나 유효하지 않습니다."
        )
    )
    else
    (
        print "Unwrap UVW Modifier를 찾을 수 없습니다."
    )2
)
else
(
    print "객체가 선택되지 않았습니다."
)

--$.setSelection #Edge #{17}
--$.modifiers[#Edit_Poly].SetSelection #Edge #{}
--$.modifiers[#Edit_Poly].Select #Edge #{33}

--$.modifiers[#Edit_Poly].Select #Edge #{selectedEdges}
	
	
	--subobjectLevel = 2
