namespace LambdaCore_Skeleton.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Models.Cores;

    class LStack
    {
        private LinkedList<IFragment> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<IFragment>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public void Push(IFragment item)
        {
            this.innerList.AddLast(item);
        }

        public IFragment Pop()
        {
            var pop = this.innerList.Last.Value;
            this.innerList.RemoveLast();
            return pop;
        }

        public IFragment Peek()
        {
            IFragment peekedItem = this.innerList.First();
            return peekedItem;
        }

        public Boolean IsEmpty()
        {
            return this.innerList.Count > 0;
        }
    }
}
