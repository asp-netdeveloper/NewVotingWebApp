using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewVotingWebApp.Core.Entities
{
    //This class is for Candidate Table.
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
