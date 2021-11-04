using System;
using System.Collections.Generic;
using System.Data.Common;

namespace db.dto{
    public class ClassDto{
        public long? id { get; set; }
        public long? classCodeId { get; set; }
        public string classCodeName { get; set; }
        public long? teacherId { get; set; }
        public string teacherName { get; set; }

        public ClassDto()
        {
        }

        public ClassDto(long? id, long? classCodeId, string classCodeName, long? teacherId, string teacherName)
        {
            this.id = id;
            this.classCodeId = classCodeId;
            this.classCodeName = classCodeName;
            this.teacherId = teacherId;
            this.teacherName = teacherName;
        }

        public ClassDto(DbDataReader reader)
        {
            if (reader.Read())
            {
                this.id = reader.GetInt64(0);
                this.classCodeId = reader.GetInt64(1);
                this.classCodeName = reader.GetString(2);
                this.teacherId = reader.GetInt64(3);
                this.teacherId = reader.GetInt64(3);
                this.teacherName = reader.GetString(4);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}