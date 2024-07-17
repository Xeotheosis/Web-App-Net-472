namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("tblApart")]
    public partial class tblApart
    {
        [Key]
        public int idApart { get; set; }

        public int idScara { get; set; }

        public int idBloc { get; set; }

        public int idAsoc { get; set; }

        public short? nr { get; set; }

        [StringLength(50)]
        public string proprietar { get; set; }

        public double? cpi { get; set; }

        public double? suprafata { get; set; }

        public short? nrpers { get; set; }

        [StringLength(50)]
        public string contorizare { get; set; }

        public bool platesteAr { get; set; }

        public bool PlatesteACM { get; set; }

        public bool platestecpp1 { get; set; }

        public bool platestecpp2 { get; set; }

        public bool platestecpp3 { get; set; }

        public bool platestecpp4 { get; set; }

        public bool platestecpiscara1 { get; set; }

        public bool platestecpiscara2 { get; set; }

        public bool platestecpiscara3 { get; set; }

        public bool platestecpi { get; set; }

        public short? nrperscpi { get; set; }

        public double? nrperscpp1 { get; set; }

        public short? nrperscpp2 { get; set; }

        public short? nrperscpp3 { get; set; }

        public short? nrperscpp4 { get; set; }

        public double? consumAR { get; set; }

        public double? consumACM { get; set; }

        public bool platestePierderiAR { get; set; }

        public bool platestePierderiACM { get; set; }

        public short? nrPersPierderiAR { get; set; }

        public short? nrPersPierderiACM { get; set; }

        public double? Restante { get; set; }

        public double? Incasari { get; set; }

        public double? TotalLunaTrecuta { get; set; }

        public double? Penalitati { get; set; }

        public double? PierderiAR { get; set; }

        public double? PierderiACM { get; set; }

        public double? ARval { get; set; }

        public double? ACMval { get; set; }

        public double? CPPval { get; set; }

        public double? CPIval { get; set; }

        public double? Caldura { get; set; }

        public double? TotalLuna { get; set; }

        public double? TOTAL { get; set; }

        public double? cpp1vala { get; set; }

        public double? cpp2vala { get; set; }

        public double? cpp3vala { get; set; }

        public double? cpp4vala { get; set; }

        public double? cpiasoc { get; set; }

        public double? cpiscara1 { get; set; }

        public double? cpiscara2 { get; set; }

        public double? cpiscara3 { get; set; }

        public bool platestecppasoc { get; set; }

        public double? cppasoc { get; set; }

        public short? nrPersCPPasoc { get; set; }

        public bool platestecppasoc2 { get; set; }

        public double? cppasoc2 { get; set; }

        public short? nrPersCPPasoc2 { get; set; }

        public double? temp { get; set; }

        public double? REST32 { get; set; }

        public double? tmpincas { get; set; }

        public double? Salarii { get; set; }

        public double? CheltAdmin { get; set; }

        public double? ARptACM { get; set; }

        public bool conventieCET { get; set; }

        public double? set { get; set; }

        [Column(TypeName = "money")]
        public decimal? CheltAdminAs17 { get; set; }

        [Column(TypeName = "money")]
        public decimal? TaxeSalarii { get; set; }
    }
}
