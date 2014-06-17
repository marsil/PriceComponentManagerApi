namespace PriceComponentManager.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

	[Table("Event")]
    public partial class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }	

        [Required]
        [StringLength(100)]
        public string Type { get; set; }

		[Required]
		[StringLength(100)]
		public string EntityType { get; set; }

        [Required]
        public string Data { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int Version { get; set; }
    }
}
