using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace my_project_dsw.Models;

[PrimaryKey("BusId", "AtoColumna", "AtoLetra")]
[Table("tb_asiento")]
public partial class TbAsiento
{
    [Key]
    [Column("bus_id")]
    public int BusId { get; set; }

    [Key]
    [Column("ato_letra")]
    [StringLength(1)]
    [Unicode(false)]
    public string AtoLetra { get; set; } = null!;

    [Key]
    [Column("ato_columna")]
    public int AtoColumna { get; set; }

    [Column("ato_tipo")]
    [StringLength(20)]
    [Unicode(false)]
    public string AtoTipo { get; set; } = null!;

    [Column("ato_precio", TypeName = "decimal(10, 2)")]
    public decimal AtoPrecio { get; set; }

    [Column("ato_estado")]
    public bool? AtoEstado { get; set; }

    [ForeignKey("BusId")]
    [InverseProperty("TbAsientos")]
    public virtual TbBu Bus { get; set; } = null!;

    [InverseProperty("TbAsiento")]
    public virtual ICollection<TbTransaccion> TbTransaccions { get; set; } = new List<TbTransaccion>();
}
