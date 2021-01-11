using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewVotingWebApp.Core.Entities
{
    //This class is for Vote table.
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }

        [ForeignKey("CandidateId")]
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("VoterId")]
        public int VoterId { get; set; }
        public virtual Voter Voter { get; set; }
    }
}
