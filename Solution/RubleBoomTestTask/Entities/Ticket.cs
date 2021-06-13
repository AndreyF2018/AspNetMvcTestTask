namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket
    {
        [Key]
        public int id { get; private set; }

        [StringLength(75)]
        public string comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateCreation { get; private set; }

        public int positionId { get; set; }

        public int quantityPosition { get; set; }

        public virtual Position position { get; set; }

        public Ticket(string _comment, Position _position)
        {
            this.comment = _comment;
            this.dateCreation = DateTime.Now;
            this.positionId = _position.id;
            this.position = _position;
        }

        public Ticket(Position _position)
        {
            this.dateCreation = DateTime.Now;
            this.positionId = _position.id;
            this.position = _position;
        }
        Ticket()
        {

        }
    }
}
