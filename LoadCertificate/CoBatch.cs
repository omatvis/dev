using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoadCertificate;

[Table("co_batch")]
public partial class CoBatch
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cob_fdate")]
    public DateOnly? CobFdate { get; set; }

    [Column("cob_tdate")]
    public DateOnly? CobTdate { get; set; }

    [Column("coj_type")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CojType { get; set; }

    [Column("coj_source")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CojSource { get; set; }

    [Column("cob_descr")]
    [StringLength(255)]
    [Unicode(false)]
    public string? CobDescr { get; set; }

    [Column("cob_srctype")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CobSrctype { get; set; }

    [Column("cob_srcnum")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CobSrcnum { get; set; }

    public bool? PostBatch { get; set; }

    public bool? AddToBatch { get; set; }

    [InverseProperty("CoBatch")]
    public virtual ICollection<ScCertificate> ScCertificates { get; set; } = new List<ScCertificate>();
}
