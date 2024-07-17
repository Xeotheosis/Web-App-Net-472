namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("tblAsociatii")]
    public partial class tblAsociatii
    {
        [Key]
        public int idAsoc { get; set; }

        [StringLength(100)]
        public string Denumire { get; set; }

        [StringLength(20)]
        public string denScurta { get; set; }

        [StringLength(100)]
        public string Adresa { get; set; }

        [StringLength(100)]
        public string Presedinte { get; set; }

        [StringLength(100)]
        public string Administrator { get; set; }

        [StringLength(100)]
        public string Cenzor { get; set; }

        [StringLength(50)]
        public string AnLucru { get; set; }

        [StringLength(50)]
        public string LunaLucru { get; set; }

        [StringLength(10)]
        public string Telefon { get; set; }

        public double? CoefPausalAR { get; set; }

        public double? CoefPausaACM { get; set; }

        [StringLength(50)]
        public string cpia0den { get; set; }

        [StringLength(50)]
        public string cpia1den { get; set; }

        [StringLength(50)]
        public string cpia2den { get; set; }

        [StringLength(50)]
        public string cpia3den { get; set; }

        [StringLength(50)]
        public string cpia4den { get; set; }

        [StringLength(50)]
        public string cpib0den { get; set; }

        [StringLength(50)]
        public string cpib1den { get; set; }

        [StringLength(50)]
        public string cpib2den { get; set; }

        [StringLength(50)]
        public string cpib3den { get; set; }

        [StringLength(50)]
        public string cpib4den { get; set; }

        [StringLength(50)]
        public string cpib5den { get; set; }

        [StringLength(50)]
        public string cpib6den { get; set; }

        [StringLength(50)]
        public string cpic0den { get; set; }

        [StringLength(50)]
        public string cpic1den { get; set; }

        [StringLength(50)]
        public string cpic2den { get; set; }

        [StringLength(50)]
        public string cpic3den { get; set; }

        [StringLength(50)]
        public string cpic4den { get; set; }

        [StringLength(50)]
        public string cpic5den { get; set; }

        [StringLength(50)]
        public string cppasoc1den { get; set; }

        [StringLength(50)]
        public string cppasoc2den { get; set; }

        [StringLength(50)]
        public string cpp1den { get; set; }

        [StringLength(50)]
        public string cpp2den { get; set; }

        [StringLength(50)]
        public string cpp3den { get; set; }

        [StringLength(50)]
        public string cpp4den { get; set; }

        [StringLength(50)]
        public string cpiscara0den { get; set; }

        [StringLength(50)]
        public string cpiscara1den { get; set; }

        [StringLength(50)]
        public string cpiscara2den { get; set; }

        [StringLength(50)]
        public string cpiscara3den { get; set; }

        public double? cpia0val { get; set; }

        public double? cpia1val { get; set; }

        public double? cpia2val { get; set; }

        public double? cpia3val { get; set; }

        public double? cpia4val { get; set; }

        public double? cpib0val { get; set; }

        public double? cpib1val { get; set; }

        public double? cpib2val { get; set; }

        public double? cpib3val { get; set; }

        public double? cpib4val { get; set; }

        public double? cpib5val { get; set; }

        public double? cpib6val { get; set; }

        public double? cpic0val { get; set; }

        public double? cpic1val { get; set; }

        public double? cpic2val { get; set; }

        public double? cpic3val { get; set; }

        public double? cpic4val { get; set; }

        public double? cpic5val { get; set; }

        public double? cppasoc1val { get; set; }

        public double? cppasoc2val { get; set; }

        public double? PretGcal { get; set; }

        public double? PretAR { get; set; }

        public double? PretARptACM { get; set; }

        public double? PretACM { get; set; }

        public double? PretCPI { get; set; }

        public double? TotalCPI { get; set; }

        public double? PretCPPasoc1 { get; set; }

        public double? PretCPPasoc2 { get; set; }

        public bool modRepartizareCorectie { get; set; }

        public bool tipApartCorectie { get; set; }

        public bool calculat { get; set; }

        public bool secalculeazaRestante { get; set; }

        [StringLength(50)]
        public string raportAfis { get; set; }

        public string Note { get; set; }

        [Column(TypeName = "image")]
        public byte[] scanareConsumuri { get; set; }

        public bool modRepartizareCG { get; set; }

        public double? apameteo { get; set; }

        [StringLength(50)]
        public string raportAfisIstoric { get; set; }

        public double? penalizari { get; set; }

        public bool seCalcCPPASOC1 { get; set; }

        public bool seCalcCPPASOC2 { get; set; }

        [StringLength(50)]
        public string raportCentralizator { get; set; }

        public double? PretARptACMConventii { get; set; }
    }
}
