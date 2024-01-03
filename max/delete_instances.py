-- 모든 오브젝트를 검색합니다.
objs = objects

-- "object"를 포함하는 그룹만 선택합니다.
groupObjs = for obj in objs where (isGroupHead obj) and (findString (tolower obj.name) "object") == true collect obj

-- 그룹 객체를 선택합니다.
--select groupObjs
print groupObjs

if groupObjs.count == 1 then
(
	format "찾은 오브젝트의 개수: 1\n"
    format "오브젝트 이름: %\n" groupObjs[1].name
	)
	else if groupObjs.count > 1 then
(
    -- 오브젝트가 1개보다 많은 경우의 작업을 여기에 추가합니다.
    format "찾은 오브젝트의 개수 초과: %\n" groupObjs.count
)
else
(
    -- 오브젝트를 찾지 못한 경우의 작업을 여기에 추가합니다.
    format "오브젝트를 찾지 못했습니다.\n"
)


clearSelection()
select #($gl_cas01_Object, $Model0, $Model1, $Model2, $Model3, $Model4, $Model5, $Model6, $Model7, $Model8, $Model9, $Model10, $Model11, $Model12, $Model13, $Model14, $Model15, $Model16, $Model17, $Model18, $Model19, $Model20, $Model21, $Model22, $Model23, $Model24, $Model25, $Model26, $Model27, $Model28, $Model29, $Model30, $Model31, $Model32, $Model33, $Model34, $Model35, $Model36, $Model37, $Model38, $Model39, $Model40, $Model41, $Model42, $Model43, $Model44, $Model45, $Model46, $Model47, $Model48, $Model49, $Model50, $Model51, $Model52, $Model53, $Model54, $Model55, $Model56, $Model57, $Model58, $Model59, $Model60, $Model61, $Model62, $Model63, $Model64, $Model65, $Model66, $Model67, $Model68, $Model69, $Model70, $Model71, $Model72, $Model73, $Model74, $Model75, $Model76, $Model77, $Model78, $Model79, $Model80, $Model81, $Model82, $Model83, $Model84, $Model85, $Model86, $Model87, $Model88, $Model89, $Model90, $Model91, $Model92, $Model93, $Model94, $Model95, $Model96, $Model97, $Model98, $Model99, $Model100, $Model101, $Model102, $Model103, $Model104, $Model105, $Model106, $Model107, $Model108, $Model109, $Model110, $Model111, $Model112, $Model113, $Model114, $Model115, $Model116, $Model117, $Model118, $Model119, $Model120, $Model121, $Model122, $Model123, $Model124, $Model125, $Model126, $Model127, $Model128, $Model129, $Model130, $Model131, $Model132, $Model133, $Model134, $Model135, $Model136, $Model137, $Model138, $Model139, $Model140, $Model141, $Model142, $Model143, $Model144, $Model145, $Model146, $Model147, $Model148, $Model149, $Model150, $Model151, $Model152, $Model153, $Model154, $Model155, $Model156, $Model157, $Model158, $Model159, $Model160, $Model161, $Model162, $Model163, $Model164, $Model165, $Model166, $Model167, $Model168, $Model169, $Model170, $Model171, $Model172, $Model173, $Model174, $Model175, $Model176, $Model177, $Model178, $Model179, $Model180, $Model181, $Model182, $Model183, $Model184, $Model185, $Model186, $Model187, $Model188, $Model189, $Model190, $Model191, $Model192, $Model193, $Model194, $Model195, $Model196, $Model197, $Model198, $Model199, $Model200, $Model201, $Model202, $Model203, $Model204, $Model205, $Model206, $Model207, $Model208, $Model209, $Model210, $Model211, $Model212, $Model213, $Model214, $Model215, $Model216, $Model217, $Model218, $Model219, $Model220, $Model221, $Model222, $Model223, $Model224, $Model225, $Model226, $Model227, $Model228, $Model229, $Model230, $Model231, $Model232, $Model233, $Model234, $Model235, $Model236, $Model237, $Model238, $Model239, $Model240, $Model241, $Model242, $Model243, $Model244, $Model245, $Model246, $Model247, $Model248, $Model249, $Model250, $Model251, $Model252, $Model253, $Model254, $Model255, $Model256, $Model257, $Model258, $Model259, $Model260, $Model261, $Model262, $Model263, $Model264, $Model265, $Model266, $Model267, $Model268, $Model269, $Model270, $Model271, $Model272, $Model273, $Model274, $Model275, $Model276, $Model277, $Model278, $Model279, $Model280, $Model281, $Model282, $Model283, $Model284, $Model285, $Model286, $Model287, $Model288, $Model289, $Model290, $Model291, $Model292, $Model293, $Model294, $Model295, $Model296, $Model297, $Model298, $Model299, $Model300, $Model301, $Model302, $Model303, $Model304, $Model305, $Model306, $Model307, $Model308, $Model309, $Model310, $Model311, $Model312, $Model313, $Model314, $Model315, $Model316, $Model317, $Model318, $Model319, $Model320, $Model321, $Model322, $Model323, $Model324, $Model325, $Model326, $Model327, $Model328, $Model329, $Model330, $Model331, $Model332, $Model333, $Model334, $Model335, $Model336, $Model337, $Model338, $Model339, $Model340, $Model341, $Model342, $Model343, $Model344, $Model345, $Model346, $Model347, $Model348, $Model349, $Model350, $Model351, $Model352, $Model353, $Model354, $Model355, $Model356, $Model357, $Model358, $Model359, $Model360, $Model361, $Model362, $Model363, $Model364, $Model365, $Model366, $Model367, $Model368, $Model369, $Model370, $Model371, $Model372, $Model373, $Model374, $Model375, $Model376, $Model377, $Model378, $Model379, $Model380, $Model381, $Model382, $Model383, $Model384, $Model385, $Model386, $Model387, $Model388, $Model389, $Model390, $Model391, $Model392, $Model393, $Model394, $Model395, $Model396, $Model397, $Model398, $Model399, $Model400, $Model401, $Model402, $Model403, $Model404, $Model405, $Model406, $Model407, $Model408, $Model409, $Model410, $Model411, $Model412, $Model413, $Model414, $Model415, $Model416, $Model417, $Model418, $Model419, $Model420, $Model421, $Model422, $Model423, $Model424, $Model425, $Model426, $Model427, $Model428, $Model429, $Model430, $Model431, $Model432, $Model433, $Model434, $Model435, $Model436, $Model437, $Model438, $Model439, $Model440, $Model441, $Model442, $Model443, $Model444, $Model445, $Model446, $Model447, $Model448, $Model449, $Model450, $Model451, $Model452, $Model453, $Model454, $Model455, $Model456, $Model457, $Model458, $Model459, $Model460, $Model461, $Model462, $Model463, $Model464, $Model465, $Model466, $Model467, $Model468, $Model469, $Model470, $Model471, $Model472, $Model473, $Model474, $Model475, $Model476, $Model477, $Model478, $Model479, $Model480, $Model481, $Model482, $Model483, $Model484, $Model485, $Model486, $Model487, $Model488, $Model489, $Model490, $Model491, $Model492, $Model493, $Model494, $Model495, $Model496, $Model497, $Model498, $Model499, $Model500, $Model501, $Model502, $Model503, $Model504, $Model505, $Model506, $Model507, $Model508, $Model509, $Model510, $Model511, $Model512, $Model513, $Model514, $Model515, $Model516, $Model517, $Model518, $Model519, $Model520, $Model521, $Model522, $Model523, $Model524, $Model525, $Model526, $Model527, $Model528, $Model529, $Model530, $Model531, $Model532, $Model533, $Model534, $Model535, $Model536, $Model537, $Model538, $Model539, $Model540, $Model541, $Model542, $Model543, $Model544, $Model545, $Model546, $Model547, $Model548, $Model549, $Model550, $Model551, $Model552, $Model553, $Model554, $Model555, $Model556, $Model557, $Model558, $Model559, $Model560, $Model561, $Model562, $Model563, $Model564, $Model565, $Model566, $Model567, $Model568, $Model569, $Model570, $Model571, $Model572, $Model573, $Model574, $Model575, $Model576, $Model577, $Model578, $Model579, $Model580, $Model581, $Model582, $Model583, $Model584, $Model585, $Model586, $Model587, $Model588, $Model589, $Model590, $Model591, $Model592, $Model593, $Model594, $Model595, $Model596, $Model597, $Model598, $Model599, $Model600, $Model601, $Model602, $Model603, $Model604, $Model605, $Model606, $Model607, $Model608, $Model609, $Model610, $Model611, $Model612, $Model613, $Model614, $Model615, $Model616, $Model617, $Model618, $Model619, $Model620, $Model621, $Model622, $Model623, $Model624, $Model625, $Model626, $Model627, $Model628, $Model629, $Model630, $Model631, $Model632, $Model633, $Model634, $Model635, $Model636, $Model637, $Model638, $Model639, $Model640, $Model641, $Model642, $Model643, $Model644, $Model645, $Model646, $Model647, $Model648, $Model649, $Model650, $Model651, $Model652, $Model653, $Model654, $Model655, $Model656, $Model657, $Model658, $Model659, $Model660, $Model661, $Model662, $Model663, $Model664, $Model665, $Model666, $Model667, $Model668, $Model669, $Model670, $Model671, $Model672, $Model673, $Model674, $Model675, $Model676, $Model677, $Model678, $Model679, $Model680, $Model681, $Model682, $Model683, $Model684, $Model685, $Model686, $Model687, $Model688, $Model689, $Model690, $Model691, $Model692, $Model693, $Model694, $Model695, $Model696, $Model697, $Model698, $Model699, $Model700, $Model701, $Model702, $Model703, $Model704, $Model705, $Model706, $Model707, $Model708, $Model709, $Model710, $Model711, $Model712, $Model713, $Model714, $Model715, $Model716, $Model717, $Model718, $Model719, $Model720, $Model721, $Model722, $Model723, $Model724, $Model725, $Model726, $Model727, $Model728, $Model729, $Model730, $Model731, $Model732, $Model733, $Model734, $Model735, $Model736, $Model737, $Model738, $Model739, $Model740, $Model741, $Model742, $Model743, $Model744, $Model745, $Model746, $Model747, $Model748, $Model749, $Model750, $Model751, $Model752, $Model753, $Model754, $Model755, $Model756, $Model757, $Model758, $Model759, $Model760, $Model761, $Model762, $Model763, $Model764, $Model765, $Model766, $Model767, $Model768, $Model769, $Model770, $Model771, $Model772, $Model773, $Model774, $Model775, $Model776, $Model777, $Model778, $Model779, $Model780, $Model781, $Model782, $Model783, $Model784, $Model785, $Model786, $Model787, $Model788, $Model789, $Model790, $Model791, $Model792, $Model793, $Model794, $Model795, $Model796, $Model797, $Model798, $Model799, $Model800, $Model801, $Model802, $Model803, $Model804, $Model805, $Model806, $Model807, $Model808, $Model809, $Model810, $Model811, $Model812, $Model813, $Model814, $Model815, $Model816, $Model817, $Model818, $Model819, $Model820, $Model821, $Model822, $Model823, $Model824, $Model825, $Model826, $Model827, $Model828, $Model829, $Model830, $Model831, $Model832, $Model833, $Model834, $Model835, $Model836, $Model837, $Model838, $Model839, $Model840, $Model841, $Model842, $Model843, $Model844, $Model845, $Model846, $Model847, $Model848, $Model849, $Model850, $Model851, $Model852, $Model853, $Model854, $Model855, $Model856, $Model857, $Model858, $Model859, $Model860, $Model861, $Model862, $Model863, $Model864, $Model865, $Model866, $Model867, $Model868, $Model869, $Model870, $Model871, $Model872, $Model873, $Model874, $Model875, $Model876, $Model877, $Model878, $Model879, $Model880, $Model881, $Model882, $Model883, $Model884, $Model885, $Model886, $Model887, $Model888, $Model889, $Model890, $Model891, $Model892, $Model893, $Model894, $Model895, $Model896, $Model897, $Model898, $Model899, $Model900, $Model901, $Model902, $Model903, $Model904, $Model905, $Model906, $Model907, $Model908, $Model909, $Model910, $Model911, $Model912, $Model913, $Model914, $Model915, $Model916, $Model917, $Model918, $Model919, $Model920, $Model921, $Model922, $Model923, $Model924, $Model925, $Model926, $Model927, $Model928, $Model929, $Model930, $Model931, $Model932, $Model933, $Model934, $Model935, $Model936, $Model937, $Model938, $Model939, $Model940, $Model941, $Model942, $Model943, $Model944, $Model945, $Model946, $Model947, $Model948, $Model949, $Model950, $Model951, $Model952, $Model953, $Model954, $Model955, $Model956, $Model957, $Model958, $Model959, $Model960, $Model961, $Model962, $Model963, $Model964, $Model965, $Model966, $Model967, $Model968, $Model969, $Model970, $Model971, $Model972, $Model973, $Model974, $Model975, $Model976, $Model977, $Model978, $Model979, $Model980, $Model981, $Model982, $Model983, $Model984, $Model985, $Model986, $Model987, $Model988, $Model989, $Model990, $Model991, $Model992, $Model993, $Model994, $Model995, $Model996, $Model997, $Model998, $Model999, $Model1000, $Model1001, $Model1002, $Model1003, $Model1004, $Model1005, $Model1006, $Model1007, $Model1008, $Model1009, $Model1010, $Model1011, $Model1012, $Model1013, $Model1014, $Model1015, $Model1016, $Model1017, $Model1018, $Model1019, $Model1020, $Model1021, $Model1022, $Model1023, $Model1024, $Model1025, $Model1026, $Model1027, $Model1028, $Model1029, $Model1030, $Model1031, $Model1032, $Model1033, $Model1034, $Model1035, $Model1036, $Model1037, $Model1038, $Model1039, $Model1040, $Model1041, $Model1042, $Model1043, $Model1044, $Model1045, $Model1046, $Model1047, $Model1048, $Model1049, $Model1050, $Model1051, $Model1052, $Model1053, $Model1054, $Model1055, $Model1056, $Model1057, $Model1058, $Model1059, $Model1060, $Model1061, $Model1062, $Model1063, $Model1064, $Model1065, $Model1066, $Model1067, $Model1068, $Model1069, $Model1070, $Model1071, $Model1072, $Model1073, $Model1074, $Model1075, $Model1076, $Model1077, $Model1078, $Model1079, $Model1080, $Model1081, $Model1082, $Model1083, $Model1084, $Model1085, $Model1086, $Model1087, $Model1088, $Model1089, $Model1090, $Model1091, $Model1092, $Model1093, $Model1094, $Model1095, $Model1096, $Model1097, $Model1098, $Model1099, $Model1100, $Model1101, $Model1102, $Model1103, $Model1104, $Model1105, $Model1106, $Model1107, $Model1108, $Model1109, $Model1110, $Model1111, $Model1112, $Model1113, $Model1114, $Model1115, $Model1116, $Model1117, $Model1118, $Model1119, $Model1120, $Model1121, $Model1122, $Model1123, $Model1124, $Model1125, $Model1126, $Model1127, $Model1128, $Model1129, $Model1130, $Model1131, $Model1132, $Model1133, $Model1134, $Model1135, $Model1136, $Model1137, $Model1138, $Model1139, $Model1140, $Model1141, $Model1142, $Model1143, $Model1144, $Model1145, $Model1146, $Model1147, $Model1148, $Model1149, $Model1150, $Model1151, $Model1152, $Model1153, $Model1154, $Model1155, $Model1156, $Model1157, $Model1158, $Model1159, $Model1160, $Model1161, $Model1162, $Model1163, $Model1164, $Model1165, $Model1166, $Model1167, $Model1168, $Model1169, $Model1170, $Model1171, $Model1172, $Model1173, $Model1174, $Model1175, $Model1176, $Model1177, $Model1178, $Model1179, $Model1180, $Model1181, $Model1182, $Model1183, $Model1184, $Model1185, $Model1186, $Model1187, $Model1188, $Model1189, $Model1190, $Model1191, $Model1192, $Model1193, $Model1194, $Model1195, $Model1196, $Model1197, $Model1198, $Model1199, $Model1200, $Model1201, $Model1202, $Model1203, $Model1204, $Model1205, $Model1206, $Model1207, $Model1208, $Model1209, $Model1210, $Model1211, $Model1212, $Model1213, $Model1214, $Model1215, $Model1216, $Model1217, $Model1218, $Model1219, $Model1220, $Model1221, $Model1222, $Model1223, $Model1224, $Model1225, $Model1226, $Model1227, $Model1228, $Model1229, $Model1230, $Model1231, $Model1232, $Model1233, $Model1234, $Model1235, $Model1236, $Model1237, $Model1238, $Model1239, $Model1240, $Model1241, $Model1242, $Model1243, $Model1244, $Model1245, $Model1246, $Model1247, $Model1248, $Model1249, $Model1250, $Model1251, $Model1252, $Model1253, $Model1254, $Model1255, $Model1256, $Model1257, $Model1258, $Model1259, $Model1260, $Model1261, $Model1262, $Model1263, $Model1264, $Model1265, $Model1266, $Model1267, $Model1268, $Model1269, $Model1270, $Model1271, $Model1272, $Model1273, $Model1274, $Model1275, $Model1276, $Model1277, $Model1278, $Model1279, $Model1280, $Model1281, $Model1282, $Model1283, $Model1284, $Model1285, $Model1286, $Model1287, $Model1288, $Model1289, $Model1290, $Model1291, $Model1292, $Model1293, $Model1294, $Model1295, $Model1296, $Model1297, $Model1298, $Model1299, $Model1300, $Model1301, $Model1302, $Model1303, $Model1304, $Model1305, $Model1306, $Model1307, $Model1308, $Model1309, $Model1310, $Model1311, $Model1312, $Model1313, $Model1314, $Model1315, $Model1316, $Model1317, $Model1318, $Model1319, $Model1320, $Model1321, $Model1322, $Model1323, $Model1324, $Model1325, $Model1326, $Model1327, $Model1328, $Model1329, $Model1330, $Model1331, $Model1332, $Model1333, $Model1334, $Model1335, $Model1336, $Model1337, $Model1338, $Model1339, $Model1340, $Model1341, $Model1342, $Model1343, $Model1344, $Model1345, $Model1346, $Model1347, $Model1348, $Model1349, $Model1350, $Model1351, $Model1352, $Model1353, $Model1354, $Model1355, $Model1356, $Model1357, $Model1358, $Model1359, $Model1360, $Model1361, $Model1362, $Model1363, $Model1364, $Model1365, $Model1366, $Model1367, $Model1368, $Model1369, $Model1370, $Model1371, $Model1372, $Model1373, $Model1374, $Model1375, $Model1376, $Model1377, $Model1378, $Model1379, $Model1380, $Model1381, $Model1382, $Model1383, $Model1384, $Model1385, $Model1386, $Model1387, $Model1388, $Model1389, $Model1390, $Model1391, $Model1392, $Model1393, $Model1394, $Model1395, $Model1396, $Model1397, $Model1398, $Model1399, $Model1400, $Model1401, $Model1402, $Model1403, $Model1404, $Model1405, $Model1406, $Model1407, $Model1408, $Model1409, $Model1410, $Model1411, $Model1412, $Model1413, $Model1414, $Model1415, $Model1416, $Model1417, $Model1418, $Model1419, $Model1420, $Model1421, $Model1422, $Model1423, $Model1424, $Model1425, $Model1426, $Model1427, $Model1428, $Model1429, $Model1430, $Model1431, $Model1432, $Model1433, $Model1434, $Model1435, $Model1436, $Model1437, $Model1438, $Model1439, $Model1440, $Model1441, $Model1442, $Model1443, $Model1444, $Model1445, $Model1446, $Model1447, $Model1448, $Model1449, $Model1450, $Model1451, $Model1452, $Model1453, $Model1454, $Model1455, $Model1456, $Model1457, $Model1458, $Model1459, $Model1460, $Model1461, $Model1462, $Model1463, $Model1464, $Model1465, $Model1466, $Model1467, $Model1468, $Model1469, $Model1470, $Model1471, $Model1472, $Model1473, $Model1474, $Model1475, $Model1476, $Model1477, $Model1478, $Model1479, $Model1480, $Model1481, $Model1482, $Model1483, $Model1484, $Model1485, $Model1486, $Model1487, $Model1488, $Model1489, $Model1490, $Model1491, $Model1492, $Model1493, $Model1494, $Model1495, $Model1496, $Model1497, $Model1498, $Model1499, $Model1500, $Model1501, $Model1502, $Model1503, $Model1504, $Model1505, $Model1506, $Model1507, $Model1508, $Model1509, $Model1510, $Model1511, $Model1512, $Model1513, $Model1514, $Model1515, $Model1516, $Model1517, $Model1518, $Model1519, $Model1520, $Model1521, $Model1522, $Model1523, $Model1524, $Model1525, $Model1526, $Model1527, $Model1528, $Model1529, $Model1530, $Model1531, $Model1532, $Model1533, $Model1534, $Model1535, $Model1536, $Model1537, $Model1538, $Model1539, $Model1540, $Model1541, $Model1542, $Model1543, $Model1544, $Model1545, $Model1546, $Model1547, $Model1548, $Model1549, $Model1550, $Model1551, $Model1552, $Model1553, $Model1554, $Model1555, $Model1556, $Model1557, $Model1558, $Model1559, $Model1560, $Model1561, $Model1562, $Model1563, $Model1564, $Model1565, $Model1566, $Model1567, $Model1568, $Model1569, $Model1570, $Model1571, $Model1572, $Model1573, $Model1574, $Model1575, $Model1576, $Model1577, $Model1578, $Model1579, $Model1580, $Model1581, $Model1582, $Model1583, $Model1584, $Model1585, $Model1586, $Model1587, $Model1588, $Model1589, $Model1590, $Model1591, $Model1592, $Model1593, $Model1594, $Model1595, $Model1596, $Model1597, $Model1598, $Model1599, $Model1600, $Model1601, $Model1602, $Model1603, $Model1604, $Model1605, $Model1606, $Model1607, $Model1608, $Model1609, $Model1610, $Model1611, $Model1612, $Model1613, $Model1614, $Model1615, $Model1616, $Model1617, $Model1618, $Model1619, $Model1620, $Model1621, $Model1622, $Model1623, $Model1624, $Model1625, $Model1626, $Model1627, $Model1628, $Model1629, $Model1630, $Model1631, $Model1632, $Model1633, $Model1634, $Model1635, $Model1636, $Model1637, $Model1638, $Model1639, $Model1640, $Model1641, $Model1642, $Model1643, $Model1644, $Model1645, $Model1646, $Model1647, $Model1648, $Model1649, $Model1650, $Model1651, $Model1652, $Model1653, $Model1654, $Model1655, $Model1656, $Model1657, $Model1658, $Model1659, $Model1660, $Model1661, $Model1662, $Model1663)
actionMan.executeAction 0 "40142"  -- Groups: Group Open
select $Model1606
macros.run "Selection" "SelectInstances"
deselect $Model1606
actionMan.executeAction 0 "40020"  -- Edit: Delete Objects
delete $
select $Model1606
actionMan.executeAction 0 "223"  -- Tools: Hide Selection
hide $
--------------------------------------------------------------------\\\




--중복 인스턴스 삭제 스크립트. 
--사용전 "object"이름을 포함하는 그룹으로 만들어 줄것!

-- 모든 오브젝트를 검색합니다.
objs = objects

-- "object"를 포함하는 그룹만 선택합니다.
groupObjs = for obj in objs where (isGroupHead obj) and (findString (tolower obj.name) "object") == true collect obj

-- 그룹 객체를 선택합니다.
--select groupObjs
print groupObjs

if groupObjs.count == 1 then
(
	format "찾은 오브젝트의 개수: 1\n"
    format "오브젝트 이름: %\n" groupObjs[1].name
	objectGroup=groupObjs[1]
	
	select objectGroup
	setGroupOpen objectGroup true
	
	
	selectedObjects = #()
for obj in objectGroup do
(
    if obj.isHidden == false do
    (
        append selectedObjects obj
		select obj
		macros.run "Selection" "SelectInstances"
		deselect obj
		actionMan.executeAction 0 "40020"  -- Edit: Delete Objects
		--delete $
		select obj
		actionMan.executeAction 0 "223"  -- Tools: Hide Selection
		hide obj
		
    )
)
actionMan.executeAction 0 "277"  -- Tools: Unhide All
unhide objects
	

	
	
	)
	else if groupObjs.count > 1 then
(
    -- 오브젝트가 1개보다 많은 경우의 작업을 여기에 추가합니다.
    format "찾은 오브젝트의 개수 초과: %\n" groupObjs.count
)
else
(
    -- 오브젝트를 찾지 못한 경우의 작업을 여기에 추가합니다.
    format "오브젝트를 찾지 못했습니다.\n"
)


------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------






--중복 인스턴스 삭제 스크립트. 
--사용전 "object"이름을 포함하는 그룹으로 만들어 줄것!

-- 모든 오브젝트를 검색합니다.
objs = objects

-- "object"를 포함하는 그룹만 선택합니다.
groupObjs = for obj in objs where (isGroupHead obj) and (findString (tolower obj.name) "object") == true collect obj

-- 그룹 객체를 선택합니다.
--select groupObjs
print groupObjs

if groupObjs.count == 1 then
(
	format "찾은 오브젝트의 개수: 1\n"
    format "오브젝트 이름: %\n" groupObjs[1].name
	objectGroup=groupObjs[1]
	
	select objectGroup
	setGroupOpen objectGroup true
	
	
	selectedObjects = #()
for obj in objectGroup do
(
    if obj.isHidden == false do
    (
        append selectedObjects obj
		select obj
		macros.run "Selection" "SelectInstances"
		deselect obj
		actionMan.executeAction 0 "40020"  -- Edit: Delete Objects
		--delete $
		select obj
		actionMan.executeAction 0 "223"  -- Tools: Hide Selection
		hide obj
		
    )
)
actionMan.executeAction 0 "277"  -- Tools: Unhide All
unhide objects
	
select objectGroup
setGroupOpen objectGroup false-- 그룹닫기
explodeGroup objectGroup
	
	
	)
	else if groupObjs.count > 1 then
(
    -- 오브젝트가 1개보다 많은 경우의 작업을 여기에 추가합니다.
    format "찾은 오브젝트의 개수 초과: %\n" groupObjs.count
)
else
(
    -- 오브젝트를 찾지 못한 경우의 작업을 여기에 추가합니다.
    format "오브젝트를 찾지 못했습니다.\n"
)
