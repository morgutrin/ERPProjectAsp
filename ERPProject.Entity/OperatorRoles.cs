using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPProject.Entity
{
    public class OperatorRoles
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Operator")]
        public int OperatorId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Operator Operator { get; set; }

        public virtual Role Role { get; set; }
    }
}