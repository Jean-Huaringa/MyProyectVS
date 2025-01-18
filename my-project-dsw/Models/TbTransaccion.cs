using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace my_project_dsw.Models;

[Table("tb_transaccion")]
public partial class TbTransaccion
{
    [Key]
    [Column("trn_id")]
    public int TrnId { get; set; }

    [Column("pgo_id")]
    public int PgoId { get; set; }

    [Column("rta_id")]
    public int RtaId { get; set; }

    [Column("bus_id")]
    public int BusId { get; set; }

    [Column("ato_columna")]
    public int AtoColumna { get; set; }

    [Column("ato_letra")]
    [StringLength(1)]
    [Unicode(false)]
    public string AtoLetra { get; set; } = null!;

    [Column("monto", TypeName = "decimal(10, 2)")]
    public decimal Monto { get; set; }

    [ForeignKey("PgoId")]
    [InverseProperty("TbTransaccions")]
    public virtual TbPago Pgo { get; set; } = null!;

    [ForeignKey("RtaId")]
    [InverseProperty("TbTransaccions")]
    public virtual TbRutum Rta { get; set; } = null!;

    [ForeignKey("BusId, AtoColumna, AtoLetra")]
    [InverseProperty("TbTransaccions")]
    public virtual TbAsiento TbAsiento { get; set; } = null!;
}
