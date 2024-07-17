namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("tblDenumiriScara")]
    public partial class tblDenumiriScara
    {
        [Key]
        public int idDenumire { get; set; }

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
    }
}
