using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoadCertificate;

[Table("sc_certdet")]
public partial class ScCertdet
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sc_certificate_id")]
    public int? ScCertificateId { get; set; }

    [Column("cdf_itemid")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CdfItemid { get; set; }

    [Column("cdf_period")]
    [StringLength(1)]
    [Unicode(false)]
    public string? CdfPeriod { get; set; }

    [Column("scd_amount", TypeName = "decimal(18, 2)")]
    public decimal? ScdAmount { get; set; }

    [Column("scd_text", TypeName = "text")]
    public string? ScdText { get; set; }

    [ForeignKey("ScCertificateId")]
    [InverseProperty("ScCertdets")]
    public virtual ScCertificate? ScCertificate { get; set; }
}
