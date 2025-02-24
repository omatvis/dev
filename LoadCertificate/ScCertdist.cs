using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoadCertificate;

[Table("sc_certdist")]
public partial class ScCertdist
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sc_certificate_id")]
    public int? ScCertificateId { get; set; }

    [Column("cdb_amount", TypeName = "decimal(18, 2)")]
    public decimal? CdbAmount { get; set; }

    [Column("cdb_entry")]
    public int? CdbEntry { get; set; }

    [Column("cdb_analysis")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CdbAnalysis { get; set; }

    [Column("cdb_desc")]
    [StringLength(255)]
    [Unicode(false)]
    public string? CdbDesc { get; set; }

    [Column("cdb_effdate")]
    public DateOnly? CdbEffdate { get; set; }

    [Column("cdb_qty")]
    public int? CdbQty { get; set; }

    [Column("cdb_uoq")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CdbUoq { get; set; }

    [Column("vat_code")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VatCode { get; set; }

    [Column("cdb_tax", TypeName = "decimal(18, 2)")]
    public decimal? CdbTax { get; set; }

    [Column("cdb_salestax", TypeName = "decimal(18, 2)")]
    public decimal? CdbSalestax { get; set; }

    [Column("poi_item")]
    public int? PoiItem { get; set; }

    [ForeignKey("ScCertificateId")]
    [InverseProperty("ScCertdists")]
    public virtual ScCertificate? ScCertificate { get; set; }
}
