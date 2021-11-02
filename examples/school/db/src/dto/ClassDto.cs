using System;
using System.Collections.Generic;
using System.Data.Common;

namespace DataAccessLayer.dto{
    public class ClassDto{
        public int? id { get; set; }
        public int? classCodeId { get; set; }
        public string classCodeName { get; set; }
        public int? teacherId { get; set; }
        public string teacherName { get; set; }

        public ClassDto(int? id, int? classCodeId, string classCodeName, int? teacherId, string teacherName)
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
                this.id = (int) reader.GetInt64(0);
                this.classCodeId = (int) reader.GetInt64(1);
                this.classCodeName = reader.GetString(2);
                this.teacherId = (int) reader.GetInt64(3);
                this.teacherName = reader.GetString(4);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}