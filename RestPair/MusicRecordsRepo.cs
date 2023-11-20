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

            _musicRecords[0].AddTrack(1, "Speak to Me", 90);
            _musicRecords[0].AddTrack(2, "Breathe", 163);
            _musicRecords[0].AddTrack(3, "On the Run", 216);

            _musicRecords[1].AddTrack(4, "Time", 421);
            _musicRecords[1].AddTrack(5, "The Great Gig in the Sky", 276);
            _musicRecords[1].AddTrack(6, "Money", 382);

            _musicRecords[2].AddTrack(7, "Shine On You Crazy Diamond", 810);
            _musicRecords[2].AddTrack(8, "Have a Cigar", 298);
            _musicRecords[2].AddTrack(9, "Wish You Were Here", 334  );

            _musicRecords[3].AddTrack(10, "Come Together", 259);
            _musicRecords[3].AddTrack(11, "Something", 182);
            _musicRecords[3].AddTrack(12, "Maxwell's Silver Hammer", 231);
            _musicRecords[3].AddTrack(13, "Oh! Darling", 217);


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

        public MusicRecord Add(MusicRecord record)
        {
            record.Validate();

            _musicRecords.Add(record);

            return record;
        }

        public MusicRecord? Delete(string title)
        {
            MusicRecord? tbd = _musicRecords.FirstOrDefault(x => x.Title == title);

            if (tbd == null)
            {
                return null;
            }

            _musicRecords.Remove(tbd);

            return tbd;
        }

        public MusicRecord? Update(string title, MusicRecord newRecord)
        {
            newRecord.Validate();

            MusicRecord? tbu = _musicRecords.FirstOrDefault(x => x.Title == title);

            if (tbu == null)
            {
                return null;
            }

            tbu.Title = newRecord.Title;
            tbu.Artist = newRecord.Artist;
            tbu.Release = newRecord.Release;
            tbu.Genre = newRecord.Genre;

            return tbu;
        }

        public Track AddToRecord(string musicRecord, Track track)
        {
            MusicRecord? record = _musicRecords.FirstOrDefault(x => x.Title == musicRecord);
            track.Validate();

            if (record == null)
            {
                throw new ArgumentException("Music record does not exist");
            }

            record._tracks.Add(track);
            return track;
        }

        public Track? DeleteFromRecord(string musicRecord, string track)
        {
            MusicRecord? record = _musicRecords.FirstOrDefault(x => x.Title == musicRecord);
            Track? tbd = record._tracks.FirstOrDefault(x => x.Name == track);

            if (record == null)
            {
                throw new ArgumentException("Music record does not exist");
            }

            if (tbd == null)
            {
                return null;
            }

            record._tracks.Remove(tbd);

            return tbd;
        }
        
    }
}