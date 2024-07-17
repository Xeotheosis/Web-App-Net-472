namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("tblScari")]
    public partial class tblScari
    {
        [Key]
        public int idScara { get; set; }

        public int idBloc { get; set; }

        public int idAsoc { get; set; }

        [StringLength(50)]
        public string Nume { get; set; }

        [StringLength(50)]
        public string cpiscara0den { get; set; }

        [StringLength(50)]
        public string cpiscara1den { get; set; }

        [StringLength(50)]
        public string cpiscara2den { get; set; }

        [StringLength(50)]
        public string cpiscara3den { get; set; }

        public double? cpiscara0val { get; set; }

        public double? cpiscara1val { get; set; }

        public double? cpiscara2val { get; set; }

        public double? cpiscara3val { get; set; }

        [StringLength(50)]
        public string cpp1den { get; set; }

        [StringLength(50)]
        public string cpp2den { get; set; }

        [StringLength(50)]
        public string cpp3den { get; set; }

        [StringLength(50)]
        public string cpp4den { get; set; }

        public double? cpp1val { get; set; }

        public double? cpp2val { get; set; }

        public double? cpp3val { get; set; }

        public double? cpp4val { get; set; }

        public double? PierderiARscara { get; set; }

        public double? PierderiACMscara { get; set; }

        public double? m3factAR { get; set; }

        public double? PretACM { get; set; }

        public double? m3factACM { get; set; }

        public double? taotalCPI { get; set; }

        public double? PretCPI1scara { get; set; }

        public double? PretCPI2scara { get; set; }

        public double? PretCPI3scara { get; set; }

        public double? PretCPP1 { get; set; }

        public double? PretCPP2 { get; set; }

        public double? PretCPP3 { get; set; }

        public double? PretCPP4 { get; set; }

        public double? SumOfConsumAR { get; set; }

        public double? SumOfConsumACM { get; set; }

        public double? CantPausalAR { get; set; }

        public double? CantPausalACM { get; set; }

        public double? CorectieARLei { get; set; }

        public double? CorectieACMLei { get; set; }

        [StringLength(50)]
        public string RepartizareAR { get; set; }

        [StringLength(50)]
        public string RepartizareACM { get; set; }

        public string Note { get; set; }

        public int? CheltFondScara { get; set; }

        public short? ORDINE { get; set; }

        public double? FactCaldura { get; set; }

        public bool cpp3mod { get; set; }

        public double? cpp2asoc { get; set; }

        public double? pretCpp2Asoc { get; set; }

        public string NumeScara { get; set; }
    }
}
