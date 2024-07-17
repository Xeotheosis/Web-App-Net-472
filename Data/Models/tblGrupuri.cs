namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("tblGrupuri")]
    public partial class tblGrupuri
    {
        [Key]
        public int idGrup { get; set; }

        public int? idAsoc { get; set; }

        public int? idScara { get; set; }

        public string Apartamente { get; set; }

        public string Repartizare { get; set; }

        [StringLength(255)]
        public string Nume { get; set; }
    }
}
