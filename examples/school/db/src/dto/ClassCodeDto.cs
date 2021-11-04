using System.Data.Common;

namespace db.dto{
    public class ClassCodeDto{
        public long? id { get; set; }
        public string name { get; set; }

        public ClassCodeDto()
        {
        }

        public ClassCodeDto(long? id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public ClassCodeDto(DbDataReader reader)
        {
            if (reader.Read())
            {
                this.id = reader.GetInt64(0);
                this.name = reader.GetString(1);
            }
        }
    }
}