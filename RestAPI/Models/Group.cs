using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class Group
    {
        public Group()
        {
            StudentSchedules = new HashSet<StudentSchedule>();
            Students = new HashSet<Student>();
            Teachings = new HashSet<Teaching>();
            Courses = new HashSet<Course>();
            Attachments = new HashSet<Attachment>();
        }

        [Key]
        [Column("GroupID")]
        public int GroupId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("YearID")]
        public int YearId { get; set; }
        [Column("LevelID")]
        public int LevelId { get; set; }
        [Column("MajorID")]
        public int MajorId { get; set; }
        [Column("ParentGroupID")]
        public int? ParentGroupId { get; set; }

        [ForeignKey(nameof(LevelId))]
        [InverseProperty("Groups")]
        public virtual Level Level { get; set; } = null!;
        [ForeignKey(nameof(MajorId))]
        [InverseProperty("Groups")]
        public virtual Major Major { get; set; } = null!;
        [ForeignKey(nameof(YearId))]
        [InverseProperty("Groups")]
        public virtual Year Year { get; set; } = null!;
        [InverseProperty(nameof(Assignment.Group))]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [InverseProperty(nameof(StudentSchedule.Group))]
        public virtual ICollection<StudentSchedule> StudentSchedules { get; set; }
        [InverseProperty(nameof(Student.Group))]

        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty(nameof(Teaching.Group))]
        public virtual ICollection<Teaching> Teachings { get; set; }

        [InverseProperty(nameof(Course.Group))]
        public virtual ICollection<Course> Courses { get; set; }

        [InverseProperty(nameof(Attachment.Group))]
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
