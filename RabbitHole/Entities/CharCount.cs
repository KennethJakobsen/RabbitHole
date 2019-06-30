using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RabbitHole.Entities
{
    public class CharCount 
    {
        public CharCount(Action<CharCount> empty, char character, int count)
        {
            Empty = empty;
            Character = character;
            Count = count;
        }
        private Action<CharCount> Empty { get;  }
        public char Character { get; }
        public int Count { get; private set; }

        public void Use(int num)
        {
            if(Count < num) throw new ArgumentOutOfRangeException();
            Count = Count - num;
            if (Count == 0)
                Empty(this);
        }

        
    }
}
