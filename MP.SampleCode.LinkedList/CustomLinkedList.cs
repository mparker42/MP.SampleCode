using MP.SampleCode.LinkedList.Implementation;

namespace MP.SampleCode.LinkedList
{
    public unsafe class CustomLinkedList<T>
    {
        private CustomLinkedListItem<T>? _firstItem;

        private CustomLinkedListItem<T>? GetNullableItemAtIndex(int index)
        {
            var current = _firstItem;

            for (var i = 0; i < index; i++)
            {
                if (current == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                current = current.NextItem;
            }

            if (current == null)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return current;
        }

        private CustomLinkedListItem<T> GetItemAtIndex(int index)
        {
            var result = GetNullableItemAtIndex(index);

            return result ?? throw new ArgumentOutOfRangeException(nameof(index));
        }

        public T this[int index]
        {
            get
            {
                var result = GetItemAtIndex(index);

                return *result.ThisValue;
            }
        }

        private int _count = 0;

        public int Count { get => _count; }

        public void Insert(T* item, int index)
        {
            if (index == 0)
            {
                _firstItem = new CustomLinkedListItem<T>
                {
                    NextItem = _firstItem,
                    ThisValue = item
                };
            }
            else
            {
                // Take the item before the provided index as the "NextItem" property represents the item at the provided index.
                var previousItem = GetItemAtIndex(index - 1);
                previousItem.NextItem = new CustomLinkedListItem<T>
                {
                    NextItem = previousItem.NextItem,
                    ThisValue = item
                };
            }

            _count++;
        }

        public void Insert(T* item)
        {
            Insert(item, _count);
        }

        public void Delete(int index = 0)
        {
            // "Delete" an item in the array by shifing all items to the right of it left one.
            if (index == 0)
            {
                _firstItem = _firstItem?.NextItem;
            }
            else
            {
                var previousItem = GetNullableItemAtIndex(index - 1);

                if (previousItem != null)
                {
                    previousItem.NextItem = previousItem.NextItem?.NextItem;
                }
            }

            _count--;
        }

        public IEnumerable<string> Print()
        {
            var result = new string[_count];
            var current = _firstItem;

            for (var i = 0; i < _count; i++)
            {
                result[i] = (*current!.ThisValue).ToString()!;

                current = current.NextItem;
            }

            return result;
        }
    }
}
