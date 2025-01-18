using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace my_project_dsw.Models;

[Table("tb_trabajador")]
public partial class TbTrabajador
{
    [Key]
    [Column("tbj_id")]
    public int TbjId { get; set; }

    [Column("usr_fecha_registro", TypeName = "datetime")]
    public DateTime? UsrFechaRegistro { get; set; }

    [Column("tbj_salario", TypeName = "decimal(10, 2)")]
    public decimal TbjSalario { get; set; }

    [Column("tbj_estado")]
    public bool TbjEstado { get; set; }

    [InverseProperty("Tbj")]
    public virtual ICollection<TbRutum> TbRuta { get; set; } = new List<TbRutum>();

    [ForeignKey("TbjId")]
    [InverseProperty("TbTrabajador")]
    public virtual TbUsuario Tbj { get; set; } = null!;
}
