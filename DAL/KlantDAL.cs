using System;
using Dapper;
using System.Collections.Generic;
using System.Text;
using CL;
using SQLAccess;
using Dapper;

namespace DAL
{
    public class KlantDAL : IKlantDAL, IKlantCollectionDAL
    {
		public void KlantUpdate(KlantDTO klantDTO) 
		{
			string sql = @"UPDATE [dbo].[persooninfo]
                           SET [voornaam] = @voornaam
                              , [tussenvoegsel] = @tussenvoegsel
                              , [achternaam] = @achternaam
                              , [telNr] = @telNr
						      , [postcode] = @postcode
                              , [straatNaam] = @straatNaam
                              , [huisNr] = @huisNr
							  , [DOB] = @DOB
                           WHERE [persoonInfoID] = @persoonInfoID";


			var dictionary = new Dictionary<string, object>
			{
				{"@persoonInfoID", klantDTO.PersoonInfoID},
				{"@voornaam", klantDTO.Voornaam},
				{"@tussenvoegsel", klantDTO.Tussenvoegsel},
				{"@achternaam", klantDTO.Achternaam},
				{"@telNr", klantDTO.TelNR},
				{"@postcode", klantDTO.Postcode},
				{"@straatNaam", klantDTO.StraatNaam},
				{"@huisNr", klantDTO.HuisNR},
				{"@DOB", klantDTO.DOB},
			};

			var parameters = new DynamicParameters(dictionary);

			DataBaseAccess.SaveData(sql, klantDTO);
		}
		public void KlantDagUpdate(KlantDTO klantDTO) { }
		public void CreateKlant(KlantDTO klantDTO) 
        {
            string sql = @"INSERT INTO dbo.[persooninfo] (voornaam, tussenvoegsel, achternaam, telNr, postcode, straatNaam, huisNr, DOB)
                            VALUES(@Voornaam, @Tussenvoegsel, @Achternaam, @TelNR, @Postcode, @StraatNaam, @HuisNR, @DOB);";

            DataBaseAccess.SaveData(sql, klantDTO);
        }
        public void Delete(KlantDTO klantDTO) { }
        public IEnumerable<KlantDTO> GetAllKlanten() 
        {
            string sql = @"SELECT * FROM [dbo].[persooninfo]";

            var parameters = new DynamicParameters();

            return DataBaseAccess.LoadData<KlantDTO>(sql, parameters);
        }
        public IEnumerable<KlantDTO> GetKlantById(int ID) 
        {
			string sql = @"SELECT 
								*
                            FROM 
	                            [dbo].[persooninfo]
						    WHERE [persooninfo].persoonInfoID = @ID
						  ";

			var dictionary = new Dictionary<string, object>
			{
				{"@ID", ID}
			};

			var parameters = new DynamicParameters(dictionary);

			return DataBaseAccess.LoadData<KlantDTO>(sql, parameters);
		}
		public IEnumerable<KlantDTO> GetKlantDagById(int ID)
		{
			// needs refining.
			string sql = @"SELECT 
								*
                            FROM 
	                            [dbo].[dagpersooninfo]
						    WHERE [dagpersooninfo].dagklantenID = @ID
						  ";

			var dictionary = new Dictionary<string, object>
			{
				{"@ID", ID}
			};

			var parameters = new DynamicParameters(dictionary);

			return DataBaseAccess.LoadData<KlantDTO>(sql, parameters);
		}
		public IEnumerable<KlantDTO> GetKlantenByDag(int dagID)
        {
            string sql =
            @"
            SELECT 
	            Klant.persoonInfoID,
	            Klant.voornaam,
	            Klant.tussenvoegsel,
	            Klant.achternaam,
	            Klant.telNr,
	            Klant.postcode,
	            Klant.straatNaam,
	            Klant.huisNr,
	            Klant.DOB,
                koppeltabel.aankomst,
	            koppeltabel.vertrek
            FROM 
	            [dbo].[dag]
	            LEFT JOIN [dbo].[dagpersooninfo] AS koppeltabel ON koppeltabel.dagID = [dag].dagid
	            LEFT JOIN [dbo].[persooninfo] AS klant ON Klant.persoonInfoID = koppeltabel.persoonInfoID
	            WHERE [dag].dagID = @dagID
            GROUP BY
	            Klant.persoonInfoID,
	            Klant.voornaam,
	            Klant.tussenvoegsel,
	            Klant.achternaam,
	            Klant.telNr,
	            Klant.postcode,
	            Klant.straatNaam,
	            Klant.huisNr,
	            Klant.DOB,
                koppeltabel.aankomst,
	            koppeltabel.vertrek
            ";

            var dictionary = new Dictionary<string, object>
            {
                {"@dagID", dagID}
            };

            var parameters = new DynamicParameters(dictionary);

            return DataBaseAccess.LoadData<KlantDTO>(sql, parameters);
        }
        public IEnumerable<KlantDTO> GetNotKlantenByDag(int dagID)
        {
            string sql =
            @"
            SELECT 
	            Klant.persoonInfoID,
	            Klant.voornaam,
	            Klant.tussenvoegsel,
	            Klant.achternaam,
	            Klant.telNr,
	            Klant.postcode,
	            Klant.straatNaam,
	            Klant.huisNr,
	            Klant.DOB,
                koppeltabel.aankomst,
	            koppeltabel.vertrek
            FROM 
	            [dbo].[dag]
	            LEFT JOIN [dbo].[dagpersooninfo] AS koppeltabel ON koppeltabel.dagID = [dag].dagid
	            LEFT JOIN [dbo].[persooninfo] AS klant ON Klant.persoonInfoID = koppeltabel.persoonInfoID
	            WHERE [dag].dagID = @dagID
            GROUP BY
	            Klant.persoonInfoID,
	            Klant.voornaam,
	            Klant.tussenvoegsel,
	            Klant.achternaam,
	            Klant.telNr,
	            Klant.postcode,
	            Klant.straatNaam,
	            Klant.huisNr,
	            Klant.DOB,
                koppeltabel.aankomst,
	            koppeltabel.vertrek
            ";

            var dictionary = new Dictionary<string, object>
            {
                {"@dagID", dagID}
            };

            var parameters = new DynamicParameters(dictionary);

            return DataBaseAccess.LoadData<KlantDTO>(sql, parameters);
        }
		public void AddKlantToDag(int klantID, int dagID, DateTime aankomst, DateTime vertrek)
		{
			string sql = @"INSERT INTO dbo.[dagpersooninfo] (DagID, persoonInfoID)
                            VALUES(@DagID, @persoonInfoID);";

			var dictionary = new Dictionary<string, object>
			{
				{"@persoonInfoID", klantID},
				{"@DagID", dagID},
			};

			DataBaseAccess.SaveData(sql, dictionary);
		}
		public void RemoveKlantFromDag(int KlantID, int DagID)
		{
			string sql = @"DELETE FROM [dbo].[dagpersooninfo]
                           WHERE [dagID] = @DagID AND [persoonInfoID] = @KlantID";

			var dictionary = new Dictionary<string, object>
			{
				{"@KlantID", KlantID},
				{"@DagID", DagID}
			};

			var parameters = new DynamicParameters(dictionary);

			DataBaseAccess.DeleteData<DagDTO>(sql, parameters);
		}

	}
}
