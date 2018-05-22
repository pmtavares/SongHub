﻿using SongHub.Models;
using System;


namespace SongHub.DTOS
{
    public class GigDTO
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }

        public UserDTO Artist { get; set; }
        
        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public GenreDTO Genre { get; set; }

    }
}