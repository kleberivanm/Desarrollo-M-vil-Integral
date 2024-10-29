using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MesApp.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<BsonDocument> _usuariosCollection;    

        // Constructor para establecer conexión
        public MongoDBService()
        {
            var connectionString = "mongodb://localhost:27017//"; // Reemplaza con tus credenciales
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("usuarios");
            _usuariosCollection = database.GetCollection<BsonDocument>("usuarios");
        }

        // Método para insertar un usuario
        public async Task InsertarUsuario(string correo, string contraseña)
        {
            var documento = new BsonDocument
            {
                { "correo", correo },
                { "contraseña", contraseña }
            };
            await _usuariosCollection.InsertOneAsync(documento);
        }

        // Método para buscar un usuario por correo
        public async Task<BsonDocument> ObtenerUsuario(string correo)
        {
            var filtro = Builders<BsonDocument>.Filter.Eq("correo", correo);
            return await _usuariosCollection.Find(filtro).FirstOrDefaultAsync();
        }
    }
}
