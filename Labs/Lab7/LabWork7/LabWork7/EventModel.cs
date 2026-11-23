using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class EventModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Script { get; set; } = null!;
        public string Status { get; set; } = null!;

        public bool IsExecuted
        {
            get => field;
            set
            {
                field = value;
                Status = value
                    ? "Выполнено"
                    : "Не выполнено";
            }
        }
    }
}
