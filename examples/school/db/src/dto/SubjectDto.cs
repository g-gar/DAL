using System.Data.Common;

namespace db.dto{
    public class SubjectDto{
        public int id { get; set; }
        public string name { get; set; }
        
        public SubjectDto() {}

        public SubjectDto(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public SubjectDto(DbDataReader reader)
        {
            if (reader.Read())
            {
                this.id = (int) reader.GetInt64(0);
                this.name = reader.GetString(1);
            }
        }
    }
}