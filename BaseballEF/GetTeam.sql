CREATE PROCEDURE [dbo].GetTeamByPK
	@teamnum int = 0
AS
	SELECT *
	FROM Teams T
	WHERE T.TeamPK = @teamnum
RETURN 0
