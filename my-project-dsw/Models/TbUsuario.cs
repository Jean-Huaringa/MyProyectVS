using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace my_project_dsw.Models;

[Table("tb_usuario")]
[Index("UsrEmail", Name = "UQ__tb_usuar__0F570E77B7D9435B", IsUnique = true)]
public partial class TbUsuario
{
    [Key]
    [Column("usr_id")]
    public int UsrId { get; set; }

    [Column("usr_nombre")]
    [StringLength(100)]
    public string UsrNombre { get; set; } = null!;

    [Column("usr_apellido")]
    [StringLength(100)]
    public string UsrApellido { get; set; } = null!;

    [Column("usr_email")]
    [StringLength(150)]
    public string UsrEmail { get; set; } = null!;

    [Column("usr_contrasena")]
    [StringLength(255)]
    public string UsrContrasena { get; set; } = null!;

    [Column("usr_telefono")]
    [StringLength(15)]
    public string? UsrTelefono { get; set; }

    [Column("usr_fecha_registro", TypeName = "datetime")]
    public DateTime? UsrFechaRegistro { get; set; }

    [Column("usr_state")]
    public bool? UsrState { get; set; }

    [InverseProperty("Usr")]
    public virtual ICollection<TbPago> TbPagos { get; set; } = new List<TbPago>();

    [InverseProperty("Tbj")]
    public virtual TbTrabajador? TbTrabajador { get; set; }
}
