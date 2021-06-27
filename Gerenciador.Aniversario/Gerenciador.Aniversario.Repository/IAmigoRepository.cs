using Gerenciador.Aniversario.Entity;
using System.Collections.Generic;

namespace Gerenciador.Aniversario.Repository
{
    public interface IAmigoRepository 
    {
        void DeleteAmigo(int idAmigo);
        List<Amigo> GetAll();
        Amigo GetAmigoById(int idAmigo);
        void InsertAmigo(Amigo amigo);
        void UpdateAmigo(Amigo amigo, int idAmigo);
    }
}