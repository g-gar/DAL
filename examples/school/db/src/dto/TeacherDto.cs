using System.Data.Common;

namespace db.dto{
    public class TeacherDto{
        public long id { get; set; }
        public string name { get; set; }
        // public IList<SubjectDto> subjects { get; set; }

        public TeacherDto()
        {
        }

        public TeacherDto(long id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public TeacherDto(DbDataReader reader)
        {
            if (reader.Read())
            {
                id = reader.GetInt64(0);
                name = reader.GetString(1);
            }
        }
    }
}