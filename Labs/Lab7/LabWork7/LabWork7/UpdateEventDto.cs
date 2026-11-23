using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class UpdateEventDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Script { get; set; } = null!;
    }
}
