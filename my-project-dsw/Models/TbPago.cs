using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace my_project_dsw.Models;

[Table("tb_pago")]
public partial class TbPago
{
    [Key]
    [Column("pgo_id")]
    public int PgoId { get; set; }

    [Column("usr_id")]
    public int UsrId { get; set; }

    [Column("pgo_monto", TypeName = "decimal(10, 2)")]
    public decimal PgoMonto { get; set; }

    [Column("pgo_metodo_pago")]
    [StringLength(15)]
    public string PgoMetodoPago { get; set; } = null!;

    [Column("pgo_estado")]
    [StringLength(15)]
    public string? PgoEstado { get; set; }

    [Column("pgo_fecha", TypeName = "datetime")]
    public DateTime? PgoFecha { get; set; }

    [InverseProperty("Pgo")]
    public virtual ICollection<TbTransaccion> TbTransaccions { get; set; } = new List<TbTransaccion>();

    [ForeignKey("UsrId")]
    [InverseProperty("TbPagos")]
    public virtual TbUsuario Usr { get; set; } = null!;
}
