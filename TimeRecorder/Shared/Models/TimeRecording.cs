using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeRecorder.Shared.Models
{
    public class TimeRecording : IEquatable<TimeRecording>
    {
        public Int64 ID { get; private set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public DateOnly Date { get; set; }
        public string Description { get; set; }

        public TimeRecording () : this (TimeOnly.FromDateTime(DateTime.Now), TimeOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), "")
        {
        }
        public TimeRecording(TimeOnly start, TimeOnly end, DateOnly date, string description)
        {
            ID = UniqueIdGenerator.GenerateId();
            Start = start;
            End = end;
            Date = date;
            Description = description;
        }

        public DateOnly GetDate ()
        {
            return Date;
        }

        public TimeSpan GetDuration ()
        {
            return End - Start;
        }

        public override string ToString()
        {
            return "Start: " + Start + ", End: " + End + ", Description: " + Description;
        }


        public bool Equals(TimeRecording? other)
        {
            if (other == null) return false;
            return ID.Equals(other.ID);
        }
    }
}
