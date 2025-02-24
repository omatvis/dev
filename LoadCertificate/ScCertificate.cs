using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoadCertificate;

[Table("sc_certificate")]
public partial class ScCertificate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("co_batch_id")]
    public int? CoBatchId { get; set; }

    [Column("sbs_order")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbsOrder { get; set; }

    [Column("sbm_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbmCode { get; set; }

    [Column("job_num")]
    [StringLength(50)]
    [Unicode(false)]
    public string? JobNum { get; set; }

    [Column("jph_phase")]
    [StringLength(50)]
    [Unicode(false)]
    public string? JphPhase { get; set; }

    [Column("sbs_no")]
    public int? SbsNo { get; set; }

    [Column("sbp_ref")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbpRef { get; set; }

    [Column("sbp_subref")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbpSubref { get; set; }

    [Column("sbp_valref")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbpValref { get; set; }

    [Column("sbp_qsref")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbpQsref { get; set; }

    [Column("sbp_certdate")]
    public DateOnly? SbpCertdate { get; set; }

    [Column("sbp_valdate")]
    public DateOnly? SbpValdate { get; set; }

    [Column("sbp_duedate")]
    public DateOnly? SbpDuedate { get; set; }

    [Column("sbp_hcode")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbpHcode { get; set; }

    [Column("sbp_hreason")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SbpHreason { get; set; }

    [Column("sbp_hcode2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbpHcode2 { get; set; }

    [Column("sbp_hreason2")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SbpHreason2 { get; set; }

    [Column("coj_type")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CojType { get; set; }

    [Column("vat_code")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VatCode { get; set; }

    [Column("sbp_desc")]
    [StringLength(255)]
    [Unicode(false)]
    public string? SbpDesc { get; set; }

    [Column("sbp_status")]
    [StringLength(1)]
    [Unicode(false)]
    public string? SbpStatus { get; set; }

    [Column("sbp_fulltext", TypeName = "text")]
    public string? SbpFulltext { get; set; }

    [Column("sbp_claimdate")]
    public DateOnly? SbpClaimdate { get; set; }

    [Column("bns_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string? BnsCode { get; set; }

    [Column("sbp_casappid")]
    public int? SbpCasappid { get; set; }

    [Column("sbp_caspnid")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SbpCaspnid { get; set; }

    [Column("sbp_casplid")]
    public int? SbpCasplid { get; set; }

    [Column("sbp_zero")]
    [StringLength(1)]
    [Unicode(false)]
    public string? SbpZero { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? ContraPayment { get; set; }

    [ForeignKey("CoBatchId")]
    [InverseProperty("ScCertificates")]
    public virtual CoBatch? CoBatch { get; set; }

    [InverseProperty("ScCertificate")]
    public virtual ICollection<ScCertdet> ScCertdets { get; set; } = new List<ScCertdet>();

    [InverseProperty("ScCertificate")]
    public virtual ICollection<ScCertdist> ScCertdists { get; set; } = new List<ScCertdist>();

    [InverseProperty("ScCertificate")]
    public virtual ICollection<ScCertitem> ScCertitems { get; set; } = new List<ScCertitem>();

    [InverseProperty("ScCertificate")]
    public virtual ICollection<ScVatdist> ScVatdists { get; set; } = new List<ScVatdist>();
}
