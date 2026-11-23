using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class EventService
    {
        private List<EventModel> _eventModels = new();
        public List<EventModel> GetEvents()
            =>_eventModels;

        public void AddEvent(EventModel eventModel)
            => _eventModels.Add(eventModel);

        public void UpdateEvent(UpdateEventDto updateEventDto)
        {
            var eventModel = _eventModels.FirstOrDefault(e => e.Name == updateEventDto.Name);

            if(eventModel is not null)
            {
                eventModel.Name = updateEventDto.Name;
                eventModel.Description = updateEventDto.Description;
                eventModel.Script = updateEventDto.Script;
                eventModel.StartDateTime = updateEventDto.StartDateTime;
            }
        }

        public void DeleteEvent(string eventName)
        {
            var eventModel = _eventModels.FirstOrDefault(e => e.Name == eventName);

            if (eventModel is not null)
                _eventModels.Remove(eventModel);
        }
    }
}
