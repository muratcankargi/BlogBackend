using System.ComponentModel.DataAnnotations.Schema;

namespace BlogBackend.Entities
{
    [Table("BLOGS")]
    public class Blog
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Blog()
        {

        }

        public Blog(string description)
        {
            Description = description;
        }
    }
}
