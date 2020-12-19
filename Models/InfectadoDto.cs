using System;

namespace api_mongodb.models
{
    public class InfectadoDto
    {
        public int UserId { get; set; }
         public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}