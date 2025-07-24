using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public partial class SysUser : IdentityUser
    {
       
        
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        
       
    }



}


/*public SysUserGroup()
{
    SysUsers = new HashSet<SysUser>();
    Permissions = new HashSet<Permission>();
}

[Key]
[Column("SysUserGroupID")]
public int SysUserGroupId { get; set; }
[StringLength(255)]
[Unicode(false)]
public string Name { get; set; } = null!;

[InverseProperty(nameof(SysUser.SysUserGroup))]
public virtual ICollection<SysUser> SysUsers { get; set; }

[ForeignKey("SysUserGroupId")]
[InverseProperty(nameof(Permission.SysUserGroups))]
public virtual ICollection<Permission> Permissions { get; set; }




public Permission()
        {
            SysUserGroups = new HashSet<SysUserGroup>();
        }

        [Key]
        [Column("PermissionID")]
        public int PermissionId { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [ForeignKey("PermissionId")]
        [InverseProperty(nameof(SysUserGroup.Permissions))]
        public virtual ICollection<SysUserGroup> SysUserGroups { get; set; }
*/