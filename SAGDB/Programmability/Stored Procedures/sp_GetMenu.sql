CREATE PROCEDURE [dbo].[sp_GetMenu]
	@menuID int =0
AS
 IF @menuID=0 
	SELECT
	m.MenuID,
	m.Description,
	m.ParentID,
	m.Route
FROM
	Menus m
WHERE
	m.IsActive = 1
	ELSE 
	SELECT
	m.MenuID,
	m.Description,
	m.ParentID,
	m.Route
FROM
	Menus m
WHERE
	m.IsActive = 1
	AND m.MenuID=@menuID;
