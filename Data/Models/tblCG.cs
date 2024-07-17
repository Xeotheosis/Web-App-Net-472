namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("tblCG")]
    public partial class tblCG
    {
        [StringLength(50)]
        public string FacturaCG { get; set; }

        public double? valoare { get; set; }

        [StringLength(50)]
        public string explicatie { get; set; }

        public bool tiprepartizare { get; set; }

        public string Repartizare { get; set; }

        public string Apartamente { get; set; }

        public int idScara { get; set; }

        [Key]
        public int idFacturaCG { get; set; }
    }
}
