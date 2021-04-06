public class BucketObjeto
    {
        public string key;
        //o id é a pagina
        public int id;
        public int linha;

        public BucketObjeto(string key, int id, int linha)
        {
            this.key = key;
            this.id = id;
            this.linha = linha;
        }
    }