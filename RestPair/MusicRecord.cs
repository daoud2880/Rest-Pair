using Microsoft.AspNetCore.Mvc;

namespace RestPair;

public class MusicRecord
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int? Release { get; set; }
    public string Genre { get; set; }

    public MusicRecord(string title, string artist, int release, string genre)
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

    public void ValidateArtist ()
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

    public void ValidateRealease()
    {
        if (Release <= 1000)
        {
            throw new ArgumentException("Release must be greater than 1000");
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
        if(Genre.Length <= 0)
        {
            throw new ArgumentException("Genre must be at least 1 characters long");
        }
    }
    public override string ToString()
    {
        return $"{Title}, {Artist}, {Release}, {Genre}";
    }
}

