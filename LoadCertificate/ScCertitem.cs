using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoadCertificate;

[Table("sc_certitem")]
public partial class ScCertitem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sc_certificate_id")]
    public int? ScCertificateId { get; set; }

    [Column("poi_item")]
    public int? PoiItem { get; set; }

    [Column("sbi_desc")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SbiDesc { get; set; }

    [Column("sbi_claimcum", TypeName = "decimal(18, 2)")]
    public decimal? SbiClaimcum { get; set; }

    [Column("sbi_claimtp", TypeName = "decimal(18, 2)")]
    public decimal? SbiClaimtp { get; set; }

    [Column("sbi_claimprev", TypeName = "decimal(18, 2)")]
    public decimal? SbiClaimprev { get; set; }

    [Column("sbi_certcum", TypeName = "decimal(18, 2)")]
    public decimal? SbiCertcum { get; set; }

    [Column("sbi_certtp", TypeName = "decimal(18, 2)")]
    public decimal? SbiCerttp { get; set; }

    [Column("sbi_certprev", TypeName = "decimal(18, 2)")]
    public decimal? SbiCertprev { get; set; }

    [Column("sbi_qtycum", TypeName = "decimal(18, 6)")]
    public decimal? SbiQtycum { get; set; }

    [Column("sbi_qtytp", TypeName = "decimal(18, 6)")]
    public decimal? SbiQtytp { get; set; }

    [Column("sbi_qtyprev", TypeName = "decimal(18, 6)")]
    public decimal? SbiQtyprev { get; set; }

    [Column("scd_line")]
    public int? ScdLine { get; set; }

    [Column("cdf_itemid")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CdfItemid { get; set; }

    [Column("sbi_seq")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbiSeq { get; set; }

    [Column("sbi_reason", TypeName = "text")]
    public string? SbiReason { get; set; }

    [Column("sbi_notes", TypeName = "text")]
    public string? SbiNotes { get; set; }

    [Column("sbi_subref")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbiSubref { get; set; }

    [Column("sbi_ourref")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbiOurref { get; set; }

    [Column("jwb_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string? JwbCode { get; set; }

    [Column("tsv_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TsvCode { get; set; }

    [Column("jsc_cc")]
    [StringLength(10)]
    [Unicode(false)]
    public string? JscCc { get; set; }

    [Column("sbi_cat")]
    [StringLength(1)]
    [Unicode(false)]
    public string? SbiCat { get; set; }

    [ForeignKey("ScCertificateId")]
    [InverseProperty("ScCertitems")]
    public virtual ScCertificate? ScCertificate { get; set; }
}
