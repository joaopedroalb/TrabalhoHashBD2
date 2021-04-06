using System;
using System.Collections.Generic;
using interfaceblazor.Model.Pag;

namespace interfaceblazor.Model.Hash
{
    public class Hash
    {
        //variaveis
        public static List<Pagina> paginasArr { get; set; }
        public static BucketContainer[] bucketContainer { get; set; }
        public int acessoDisco { get; set; } 
        public int colisoes { get; set; }

        public Hash(){
            paginasArr = new List<Pagina>();
            bucketContainer  = new BucketContainer[51839];
            acessoDisco = 0;
            colisoes  = 0;
        }

        //funcoes
        public static int amazingHashLogic(string nome)
        {
            int tamanhoMod = 51839;
            long sum = 0, mult = 1;
            for (int i = 0; i < nome.Length; i++)
            {
                mult = (i % 4 == 0) ? 1 : mult * 256;
                sum += nome[i] * mult;
            }
            return (int)(Math.Abs(sum) % tamanhoMod);
        }

        public void adicionarHash(string nome, int id, int linha)
        {
            int hashLogic = amazingHashLogic(nome);
            if (bucketContainer[hashLogic] == null)
            {
                bucketContainer[hashLogic] = new BucketContainer(new BucketObjeto(nome, id, linha));
            }
            else
            {
                bucketContainer[hashLogic].adicionar(new BucketObjeto(nome, id, linha));
                colisoes++;
                bucketContainer[hashLogic].colisao++;
            }
        }

        public string buscarKey(string key)
        {
            string info = "";
            int keyHash = amazingHashLogic(key);
            Boolean achou = false;
            if (bucketContainer[amazingHashLogic(key)] != null)
            {
                foreach (Bucket bc in bucketContainer[amazingHashLogic(key)].buckets)
                {
                    foreach (BucketObjeto bo in bc.vetorBO)
                    {
                        if (bo != null)
                        {
                            if (bo.key.ToLower() == key.ToLower())
                            {
                                string nomeAux = paginasArr[bo.id].linhas[bo.linha - 1];
                                info += $"ID da pagina: {bo.id}\r";
                                info += $"Linha da pagina: {bo.linha}\r";
                                info += $"Nome: {nomeAux}\n";
                                acessoDisco++;
                                achou = true;
                                break;
                            }
                        }
                    }
                    if (achou)
                        break;
                }
                if (!achou)
                    info = $"Não foi achado ninguem chamado {key}";
            }
            return info;
        }

        public static List<int> OverflowArr()
        {
            List<int> overflowArr = new List<int>();
            int indexAux = 0;
            foreach (BucketContainer bc in bucketContainer)
            {
                if (bc != null)
                {
                    if (bc.buckets[0].overflow)
                     overflowArr.Add(indexAux);
                }
                indexAux++;
            }
            return overflowArr;
        }

        public static int numOverflow(){
            return OverflowArr().Count;
        }

        public static int overflowTotal(){
            int overflowTotais = 0;
            foreach(int index in OverflowArr()){
                overflowTotais += bucketContainer[index].buckets.Count;
            }
            return overflowTotais;
        }

    }
}