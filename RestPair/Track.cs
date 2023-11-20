using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPair
{
    public class Track
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }
        
        public Track(int id, string name, int? duration)
        {
            Id = id;
            Name = name;
            Duration = duration;
        }


        public void ValidateId()
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be greater than 0");
            }
            if (Id == null)
            {
                throw new ArgumentNullException("Id cannot be null");
            }
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("Name cannot be null");
            }
            if (Name.Length <= 0)
            {
                throw new ArgumentException("Name must be at least 1 characters long");
            }
        }

        public void ValidateDuration()
        {
            if (Duration <= 0)
            {
                throw new ArgumentOutOfRangeException("Duration must be greater than 0");
            }
            if (Duration == null)
            {
                throw new ArgumentNullException("Duration cannot be null");
            }
        }

        public void Validate()
        {
            ValidateId();
            ValidateName();
            ValidateDuration();
        }

    }
}