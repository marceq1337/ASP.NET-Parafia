using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace parafia2.Models.DataLayer;

[Table("Msze")]
public partial class Msze
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("Data_mszy", TypeName = "date")]
    [Display(Name = "Data Mszy")]
    public DateTime? DataMszy { get; set; }

    [Column("ksiadz")]
    public int? Ksiadz { get; set; }

    [Column("ministrant")]
    public int? Ministrant { get; set; }

    [ForeignKey("Ksiadz")]
    [InverseProperty("Mszes")]
    [Display(Name ="Przypisany Ksiadz")]
    public virtual Ksieza? KsiadzNavigation { get; set; }

    [ForeignKey("Ministrant")]
    [InverseProperty("Mszes")]
    [Display(Name = "Przypisany Ministrant")]
    public virtual Ministranci? MinistrantNavigation { get; set; }
}
