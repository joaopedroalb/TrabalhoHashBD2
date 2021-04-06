public class Bucket
    {
        public BucketObjeto[] vetorBO = new BucketObjeto[9];
        public int index = 0;
        public bool overflow = false;

        public void add(BucketObjeto bucket)
        {
            vetorBO[index] = bucket;
            index++;
        }

        public Bucket(BucketObjeto bo)
        {
            add(bo);
        }

    }