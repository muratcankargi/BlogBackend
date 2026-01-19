using BlogBackend.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogBackend.Entities
{
    [Table("BLOGS")]
    public class Blog
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("TITLE")]
        public string Title { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column("UPDATED_AT")]
        public DateTime UpdatedAt { get; private set; }

        public Blog()
        {

        }

        public Blog(string title, string description)
        {
            SetTitle(title);
            SetDescription(description);
        }
        public void Touch() => UpdatedAt = DateTime.Now;
        public void SetDescription(string description)
        {
            CheckValidation.CheckStringValue(description);
            Description = description;
            Touch();
        }
        public void SetTitle(string title)
        {
            CheckValidation.CheckStringValue(title);
            Title = title;
            Touch();
        }
    }
}
