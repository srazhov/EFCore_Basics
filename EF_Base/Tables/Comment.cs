using System;

namespace EF_Base.Tables
{
    public class Comment
    {
        public int Id { get; set; }

        public string CommentText { get; set; }
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }        
        public Product Product { get; set; }
    }
}
