using Microsoft.AspNetCore.Mvc;

namespace RestPair;

public class MusicRecord
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int? Release { get; set; }
    public string Genre { get; set; }
    public List<Track> _tracks = new List<Track>();
    public int nextId = 1;

    public MusicRecord(string title, string artist, int? release, string genre)
    {
        Title = title;
        Artist = artist;
        Release = release;
        Genre = genre;
    }

    public void ValidateTitle()
    {
        if (Title == null)
        {
            throw new ArgumentNullException("Title cannot be null");   
        }
        if (Title.Length <= 0)
        {
            throw new ArgumentException("Title must be at least 1 characters long");
        }

    }

    public void ValidateArtist()
    {
        if (Artist == null)
        {
            throw new ArgumentNullException("Artist cannot be null");
        }
        if (Artist.Length <= 0)
        {
            throw new ArgumentException("Artist must be at least 1 characters long");
        }
    }

    public void ValidateRelease()
    {
        if (Release <= 1000)
        {
            throw new ArgumentOutOfRangeException("Release must be greater than 1000");
        }
        if (Release == null)
        {
            throw new ArgumentNullException("Release cannot be null");
        }
    }
    public void ValidateGenre()
    {
        if (Genre == null)
        {
            throw new ArgumentNullException("Genre cannot be null");
        }
        if (Genre.Length <= 0)
        {
            throw new ArgumentException("Genre must be at least 1 characters long");
        }
    }

    public void Validate()
    {
        ValidateTitle();
        ValidateArtist();
        ValidateRelease();
        ValidateGenre();
    }
    public List<Track> AddTrack(int id, string name, int? duration)
        {
            _tracks.Add(new Track(nextId, name, duration));
            nextId++;
            return _tracks;
        }

    public override string ToString()
    {
        string? tracks = "";

        foreach (Track t in _tracks)
        {
            tracks = tracks + $"{t.Id},{t.Name},{t.Duration}, ";
        }

        return $"{Title}, {Artist}, {Release}, {Genre}, {tracks}";
    }
}

