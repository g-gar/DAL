using System.Data.Common;

namespace DataAccessLayer.dto{
    public class PrincipalDto{
        public int id { get; set; }
        public string  name { get; set; }
        
        public PrincipalDto() {}

        public PrincipalDto(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public PrincipalDto(DbDataReader reader)
        {
            if (reader.Read())
            {
                this.id = (int) reader.GetInt64(0);
                this.name = reader.GetString(1);
            }
        }
    }
}