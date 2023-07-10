using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExamenRadSuanyIngris.Model
{
    public class ClassContactos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [MaxLength(100), NotNull]
        public string Nombres { get; set; }
        [MaxLength(100), NotNull]
        public string Apellidos { get; set; }
        [MaxLength(3)]
        public int Edad { get; set; }
        [MaxLength(100), NotNull]
        public string Pais { get; set; }
        [MaxLength(200), NotNull]
        public string Nota { get; set; }
        public byte[] Imagen { get; set; }

    }
}
