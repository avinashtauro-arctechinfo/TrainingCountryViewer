﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CountryViewer.DataAccess.Models;

[Table("Country")]
public partial class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(2)]
    [Unicode(false)]
    public string Code { get; set; }

    [Column(TypeName = "decimal(10, 6)")]
    public decimal Latitude { get; set; }

    [Column(TypeName = "decimal(10, 6)")]
    public decimal Longitude { get; set; }

    [Required]
    [StringLength(500)]
    [Unicode(false)]
    public string Name { get; set; }

    public int? ContinentId { get; set; }

    [ForeignKey("ContinentId")]
    [InverseProperty("Countries")]
    public virtual Continent Continent { get; set; }
}