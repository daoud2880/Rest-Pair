using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestPair
{
    public class MusicRecordsRepo
    {
        private List<MusicRecord> _musicRecords;
        public MusicRecordsRepo()
        {
            _musicRecords = new List<MusicRecord>();
            _musicRecords.Add(new MusicRecord("The Dark Side of the Moon", "Pink Floyd", 1973, "Progressive rock"));
            _musicRecords.Add(new MusicRecord("The Wall", "Pink Floyd", 1979, "Progressive rock"));
            _musicRecords.Add(new MusicRecord("Wish You Were Here", "Pink Floyd", 1975, "Progressive rock"));
            _musicRecords.Add(new MusicRecord("Abbey Road", "The Beatles", 1969, "Rock"));
        }

        public List<MusicRecord> GetAllMusicRecords(string? filter = null)
        {
            List<MusicRecord> copy = new List<MusicRecord>();

            if (filter != null)
            {
                foreach (MusicRecord item in _musicRecords) 
                {
                    if (item.Title.Contains(filter) || item.Artist.Contains(filter) || item.Genre.Contains(filter))
                    {
                        copy.Add(item);
                    }
                }

            }
            else
            {
                copy = new List<MusicRecord>(_musicRecords);
            }

            return copy;
        }
        
    }
}