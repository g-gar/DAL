using System.Collections.Generic;
using System.Data.Common;

namespace db.dto{
    public class SchoolDto{
        public int? id { get; set; }
        public string name { get; set; }
        public int? principalId { get; set; }
        public string principalName { get; set; }

        public SchoolDto(int? id, string name, int? principalId, string principalName)
        {
            this.id = id;
            this.name = name;
            this.principalId = principalId;
            this.principalName = principalName;
        }

        public SchoolDto(DbDataReader reader)
        {
            if (reader.Read())
            {
                this.id = (int) reader.GetInt64(0);
                this.name = reader.GetString(1);
                this.principalId = (int) reader.GetInt64(2);
                this.principalName = reader.GetString(3);
            }
        }
    }
}