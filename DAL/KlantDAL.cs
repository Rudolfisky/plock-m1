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
        public void Update() 
        { 
        
        }
        public void Create(KlantDTO klantDTO) { }
        public void Delete(KlantDTO klantDTO) { }
        public IEnumerable<KlantDTO> GetAllKlanten() 
        {
            string sql = @"SELECT * FROM [dbo].[persooninfo]";

            var parameters = new DynamicParameters();

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
    }
}
