namespace eFormSqlController
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class site_workers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("site")]
        public int? site_id { get; set; }

        [ForeignKey("worker")]
        public int? worker_id { get; set; }

        public int? microting_uid { get; set; }

        public int? version { get; set; }

        [StringLength(255)]
        public string workflow_state { get; set; }


        public DateTime? created_at { get; set; }


        public DateTime? updated_at { get; set; }

        public virtual sites site { get; set; }

        public virtual workers worker { get; set; }
    }
}
