namespace ClassLibraryEntityFrameworkClaseAsProp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("tblDenumiri")]
    public partial class tblDenumiri
    {
        [Key]
        public int idDenumire { get; set; }

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
    }
}
