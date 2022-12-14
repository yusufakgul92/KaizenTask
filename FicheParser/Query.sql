SELECT 
    c.Name, 
	c.Detail, 
	STUFF((SELECT ',' + Link FROM ContentImage ci WHERE ci.ContentId = c.Id  FOR XML PATH('')), 1, 1, '') AS ImageUrls,  
    c.Category 
FROM Content c 
INNER JOIN ContentLangDetail e ON c.LangId = e.Id 
WHERE e.LangCode = 'tr' 