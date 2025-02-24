using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoadCertificate;

[Table("sc_vatdist")]
public partial class ScVatdist
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sc_certificate_id")]
    public int? ScCertificateId { get; set; }

    [Column("vat_code")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VatCode { get; set; }

    [Column("sva_cur_vat_1", TypeName = "decimal(18, 2)")]
    public decimal? SvaCurVat1 { get; set; }

    [Column("sva_cur_examt_1", TypeName = "decimal(18, 2)")]
    public decimal? SvaCurExamt1 { get; set; }

    [ForeignKey("ScCertificateId")]
    [InverseProperty("ScVatdists")]
    public virtual ScCertificate? ScCertificate { get; set; }
}
