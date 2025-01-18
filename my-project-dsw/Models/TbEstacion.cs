using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace my_project_dsw.Models;

[Table("tb_estacion")]
public partial class TbEstacion
{
    [Key]
    [Column("stn_id")]
    public int StnId { get; set; }

    [Column("stn_name")]
    public int StnName { get; set; }

    [InverseProperty("Destino")]
    public virtual ICollection<TbRutum> TbRutumDestinos { get; set; } = new List<TbRutum>();

    [InverseProperty("Origen")]
    public virtual ICollection<TbRutum> TbRutumOrigens { get; set; } = new List<TbRutum>();
}
