namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("tblACM")]
    public partial class tblACM
    {
        [Key]
        public int idFacturaACM { get; set; }

        [StringLength(50)]
        public string FacturaACM { get; set; }

        public double? NrGcal { get; set; }

        public double? ValGcal { get; set; }

        public double? m3AR { get; set; }

        public double? ValAr { get; set; }

        public double? ValTotACM { get; set; }

        [StringLength(250)]
        public string Scari { get; set; }

        [StringLength(250)]
        public string Repartizare { get; set; }

        public int idAsoc { get; set; }
    }
}
