using apicsharp.Models;

namespace apicsharp.Repo
{
    public interface IRepo
    {
        void Criar(Produto prod);
        string ObterPorId(string id);
        string ObterNomeBanco();
        void Atualizar(Produto prod);
    }
}
