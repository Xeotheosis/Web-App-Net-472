namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("tblAR")]
    public partial class tblAR
    {
        [Key]
        public int idFactAR { get; set; }

        [StringLength(50)]
        public string Factura { get; set; }

        public double? Valoare { get; set; }

        public double? ValoareFaraApaMeteo { get; set; }

        [StringLength(250)]
        public string Repartizare { get; set; }

        [StringLength(250)]
        public string Scari { get; set; }

        public double? m3 { get; set; }

        public int idAsoc { get; set; }
    }
}
