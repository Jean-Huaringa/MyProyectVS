using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace my_project_dsw.Models;

[Table("tb_bus")]
[Index("BusPlaca", Name = "UQ__tb_bus__CCDDA183010D277D", IsUnique = true)]
public partial class TbBu
{
    [Key]
    [Column("bus_id")]
    public int BusId { get; set; }

    [Column("bus_placa")]
    [StringLength(20)]
    public string BusPlaca { get; set; } = null!;

    [Column("bus_modelo")]
    [StringLength(50)]
    public string BusModelo { get; set; } = null!;

    [Column("bus_capacidad_asientos")]
    public int BusCapacidadAsientos { get; set; }

    [Column("bus_estado")]
    public bool? BusEstado { get; set; }

    [InverseProperty("Bus")]
    public virtual ICollection<TbAsiento> TbAsientos { get; set; } = new List<TbAsiento>();

    [InverseProperty("Bus")]
    public virtual ICollection<TbRutum> TbRuta { get; set; } = new List<TbRutum>();
}
