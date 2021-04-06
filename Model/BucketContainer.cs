using System.Collections.Generic;

public class BucketContainer
    {
        public List<Bucket> buckets = new List<Bucket>();

        public int colisao { get; set; } = 0;

        public void adicionar(BucketObjeto bucketObj)
        {
            Bucket bucketCond = buckets[buckets.Count - 1];

            if (bucketCond.index < bucketCond.vetorBO.Length)
            {
                buckets[buckets.Count - 1].add(bucketObj);
            }
            else
            {
                buckets[buckets.Count - 1].overflow = true;
                buckets.Add(new Bucket(bucketObj));
            }

        }

        public BucketContainer(BucketObjeto bucketObj)
        {
            buckets.Add(new Bucket(bucketObj));
        }

    }