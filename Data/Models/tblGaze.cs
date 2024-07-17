namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("tblGaze")]
    public partial class tblGaze
    {
        [Key]
        public int idFactGaze { get; set; }

        [StringLength(50)]
        public string Factura { get; set; }

        public double? Valoare { get; set; }

        [StringLength(250)]
        public string Repartizare { get; set; }

        [StringLength(250)]
        public string Scari { get; set; }

        public int idAsoc { get; set; }
    }
}
