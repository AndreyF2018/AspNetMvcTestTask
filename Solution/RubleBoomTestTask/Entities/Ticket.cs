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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(75)]
        public string comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateCreation { get; set; }

        public int positionId { get; set; }

        public int quantityPosition { get; set; }

        public virtual Position position { get; set; }

        public Ticket()
        {

        }

        public Ticket(Position _position, int _quantityPosition, string _comment = "")
        {
            this.positionId = _position.id;
            this.position = _position;
            this.quantityPosition = _quantityPosition;
            this.comment = _comment;
            this.dateCreation = DateTime.Now;
        }

        public override string ToString()
        {
            return "id = " + this.id.ToString() + ". " + this.positionId.ToString() + ". " + this.comment + " " + this.dateCreation.ToString() + " " + this.quantityPosition.ToString();
        }
    }
}
