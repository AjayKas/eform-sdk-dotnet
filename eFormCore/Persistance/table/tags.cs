﻿namespace eFormSqlController
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tags
    {
        public tags()
        {
            this.taggings = new HashSet<taggings>();
            //this.check_lists = new HashSet<check_lists>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? taggings_count { get; set; }

        public int? version { get; set; }

        [StringLength(255)]
        public string workflow_state { get; set; }

        public virtual ICollection<taggings> taggings { get; set; }

        //public virtual ICollection<check_lists> check_lists { get; set; }
    }
}
