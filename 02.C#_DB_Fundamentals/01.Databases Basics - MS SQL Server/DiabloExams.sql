--1
SELECT c.Name
  FROM [dbo].[Characters] AS c
  ORDER BY c.Name
  --2
  SELECT TOP 50 g.Name as Game, CONVERT(CHAR(10), g.Start, 126) AS Start
    FROM [dbo].[Games] AS g
   WHERE g.Start BETWEEN '2011-01-01' AND '2012-12-31' 
   ORDER BY g.Start ASC, g.Name ASC