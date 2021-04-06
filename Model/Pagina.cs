
namespace interfaceblazor.Model.Pag{
    public class Pagina
    {
        public string[] linhas;
        public int index = 0;

        public Pagina(int tamanho)
        {
            linhas = new string[tamanho];
            index = 0;
        }

        public void adicionarNaPag(string s)
        {
            linhas[index] = s;
            index++;

        }

    }
}
