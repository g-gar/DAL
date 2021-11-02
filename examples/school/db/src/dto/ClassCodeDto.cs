using System.Data.Common;

namespace DataAccessLayer.dto{
    public class ClassCodeDto{
        public int? id { get; set; }
        public string name { get; set; }

        public ClassCodeDto()
        {
        }

        public ClassCodeDto(int? id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public ClassCodeDto(DbDataReader reader)
        {
            if (reader.Read())
            {
                this.id = (int) reader.GetInt64(0);
                this.name = reader.GetString(1);
            }
        }
    }
}