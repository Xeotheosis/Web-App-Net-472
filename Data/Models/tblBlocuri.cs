namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("tblBlocuri")]
    public partial class tblBlocuri
    {
        [Key]
        public int idBloc { get; set; }

        [StringLength(50)]
        public string Bloc { get; set; }

        public int idAsoc { get; set; }

        [StringLength(50)]
        public string Strada { get; set; }
    }
}
