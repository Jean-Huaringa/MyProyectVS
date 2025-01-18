using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace my_project_dsw.Models;

[Table("tb_ruta")]
public partial class TbRutum
{
    [Key]
    [Column("rta_id")]
    public int RtaId { get; set; }

    [Column("origen_id")]
    public int OrigenId { get; set; }

    [Column("destino_id")]
    public int DestinoId { get; set; }

    [Column("tbj_id")]
    public int TbjId { get; set; }

    [Column("bus_id")]
    public int BusId { get; set; }

    [Column("rta_duracion")]
    public TimeOnly RtaDuracion { get; set; }

    [Column("rta_precio", TypeName = "decimal(10, 2)")]
    public decimal RtaPrecio { get; set; }

    [Column("rta_estado")]
    public bool? RtaEstado { get; set; }

    [Column("rta_monto", TypeName = "decimal(10, 2)")]
    public decimal RtaMonto { get; set; }

    [ForeignKey("BusId")]
    [InverseProperty("TbRuta")]
    public virtual TbBu Bus { get; set; } = null!;

    [ForeignKey("DestinoId")]
    [InverseProperty("TbRutumDestinos")]
    public virtual TbEstacion Destino { get; set; } = null!;

    [ForeignKey("OrigenId")]
    [InverseProperty("TbRutumOrigens")]
    public virtual TbEstacion Origen { get; set; } = null!;

    [InverseProperty("Rta")]
    public virtual ICollection<TbTransaccion> TbTransaccions { get; set; } = new List<TbTransaccion>();

    [ForeignKey("TbjId")]
    [InverseProperty("TbRuta")]
    public virtual TbTrabajador Tbj { get; set; } = null!;
}
