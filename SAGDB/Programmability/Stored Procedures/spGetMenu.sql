CREATE PROCEDURE [dbo].[spGetMenu]
	@menuID int =0
AS
 IF @menuID=0 
	SELECT
	m.MenuID,
	m.Description,
	m.ParentID,
	m.Route
FROM
	Menu m
WHERE
	m.IsActive = 1
	ELSE 
	SELECT
	m.MenuID,
	m.Description,
	m.ParentID,
	m.Route
FROM
	Menu m
WHERE
	m.IsActive = 1
	AND m.MenuID=@menuID;
