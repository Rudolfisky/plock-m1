using System;
using System.Collections.Generic;
using System.Text;
using CL;
using SQLAccess;
using Dapper;

namespace DAL
{
    public class DagDAL : IDagDAL, IDagCollectionDAL
    {
        public void Update()
        {

        }
        public IEnumerable<DagDTO> GetDagById(int ID) 
        {
			string sql = @"SELECT 
	                            [dag].[dagID], 
	                            [dag].[date], 
	                            [dag].[dagType], 
	                            [dag].[naam], 
	                            [dag].[beschrijving], 
	                            [dag].[beginTijd], 
	                            [dag].[eindTijd], 
	                            [dag].[gebruikerID],
	                            COUNT(koppeltabel.dagid) AS klanten
                            FROM 
	                            [dbo].[dag]
	                            LEFT JOIN [dbo].[dagpersooninfo] as koppeltabel ON koppeltabel.dagID = [dag].dagid
						    WHERE [dag].dagID = @ID
                            GROUP BY
	                            [dag].[dagID], 
	                            [dag].[date], 
	                            [dag].[dagType], 
	                            [dag].[naam], 
	                            [dag].[beschrijving], 
	                            [dag].[beginTijd], 
	                            [dag].[eindTijd], 
	                            [dag].[gebruikerID]";

			var dictionary = new Dictionary<string, object>
			{
				{"@ID", ID}
			};

			var parameters = new DynamicParameters(dictionary);

			return DataBaseAccess.LoadData<DagDTO>(sql, parameters);
		}
        public void Delete(DagDTO klantDTO) { }
        public IEnumerable<DagDTO> GetAllDagen()
        {
            string sql = @"SELECT 
	                            [dag].[dagID], 
	                            [dag].[date], 
	                            [dag].[dagType], 
	                            [dag].[naam], 
	                            [dag].[beschrijving], 
	                            [dag].[beginTijd], 
	                            [dag].[eindTijd], 
	                            [dag].[gebruikerID],
	                            COUNT(koppeltabel.dagid) AS klanten
                            FROM 
	                            [dbo].[dag]
	                            LEFT JOIN [dbo].[dagpersooninfo] as koppeltabel ON koppeltabel.dagID = [dag].dagid
                            GROUP BY
	                            [dag].[dagID], 
	                            [dag].[date], 
	                            [dag].[dagType], 
	                            [dag].[naam], 
	                            [dag].[beschrijving], 
	                            [dag].[beginTijd], 
	                            [dag].[eindTijd], 
	                            [dag].[gebruikerID]";

            var parameters = new DynamicParameters();

            return DataBaseAccess.LoadData<DagDTO>(sql, parameters);
        }
        public void CreateDag(DagDTO dagDTO) 
        {
            string sql = @"INSERT INTO dbo.[Dag] (gebruikerID, Date, DagType, Naam, Beschrijving, BeginTijd, EindTijd)
                            VALUES(@UserID, @Date, @DagType, @Naam, @Beschrijving, @BeginTijd, @EindTijd);";

            DataBaseAccess.SaveData(sql, dagDTO);
        }
		public void UpdateDag(DagDTO dagDTO) 
		{
			string sql = @"UPDATE [dbo].[dag]
                           SET [date] = @date
                              , [dagType] = @dagType
                              , [naam] = @naam
                              , [beschrijving] = @beschrijving
                              , [beginTijd] = @beginTijd
                              , [eindTijd] = @eindTijd
                           WHERE [dagID] = @dagID";


			var dictionary = new Dictionary<string, object>
			{
				{"@dagID", dagDTO.dagID},
				{"@date", dagDTO.Date},
				{"@dagType", dagDTO.DagType},
				{"@naam", dagDTO.Naam},
				{"@beschrijving", dagDTO.Beschrijving},
				{"@beginTijd", dagDTO.BeginTijd},
				{"@eindTijd", dagDTO.EindTijd},
			};

			var parameters = new DynamicParameters(dictionary);

			DataBaseAccess.SaveData(sql, dagDTO);
		}

	}
}
