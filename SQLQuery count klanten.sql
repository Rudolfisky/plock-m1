SELECT 
	[dag].id, 
	COUNT(koppeltabel) AS num_klant
FROM 
	[dbo].[dag]
	LEFT JOIN [dbo].[dagpersooninfo] as koppeltabel ON koppeltabel.dagID = [dag].dagid
GROUP BY
[dag].id
