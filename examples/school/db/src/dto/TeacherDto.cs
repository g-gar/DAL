using System.Data.Common;

namespace DataAccessLayer.dto{
    public class TeacherDto{
        public int? id { get; set; }
        public string name { get; set; }
        // public IList<SubjectDto> subjects { get; set; }

        public TeacherDto(int? id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public TeacherDto(DbDataReader reader)
        {
            if (reader.Read())
            {
                id = (int)reader.GetInt64(0);
                name = reader.GetString(1);
            }
        }
    }
}