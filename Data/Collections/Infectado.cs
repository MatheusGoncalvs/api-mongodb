using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace api_mongodb.data.collections
{
    public class Infectado
    {
        public int UserId { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Infectado(int userId, DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.UserId = userId;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }        
    }
}