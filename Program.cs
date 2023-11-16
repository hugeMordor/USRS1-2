using System.Diagnostics;

namespace USRS1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            LinkedList<int> linkList = new LinkedList<int>();
            for (int i = 0; i < 100000; i++)
            {
                int temp = random.Next(1000);
                while (i == 0 && temp == 0)
                {
                    temp = random.Next(1000);
                }
                list.Add(temp);
                linkList.AddLast(temp);
            }
            void ListChanger()
            {
                int index = 1;
                while (index < list.Count)
                {
                    if (list[index] % list[0] == 0)
                    {
                        list.RemoveAt(index);
                    }
                    else
                    {
                        index++;
                    }
                }
                index = 0;
                while (index < list.Count - 1)
                {
                    if (list[index] % 2 == list[index + 1] % 2)
                    {
                        list.Insert(index + 1, 0);
                        index += 2;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            void LinkedListChanger()
            {
                var currentNode = linkList.First;
                while (currentNode != null)
                {
                    if (currentNode.Next?.Value % linkList.First?.Value == 0)
                    {
                        linkList.Remove(currentNode.Next);
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                    }
                }
                currentNode = linkList.First;
                while (currentNode != null)
                {
                    if (currentNode.Value % 2 == currentNode.Next?.Value % 2)
                    {
                        linkList.AddAfter(currentNode, 0);
                        currentNode = currentNode.Next?.Next;
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                    }
                }
            }
            Stopwatch sw = Stopwatch.StartNew();
            ListChanger();
            Console.Write("List time: ");
            Console.WriteLine(sw.Elapsed.ToString());
            sw.Restart();
            LinkedListChanger();
            Console.Write("LinkedList time: ");
            Console.WriteLine(sw.Elapsed.ToString());
            sw.Stop();
            bool isEqual = true;
            var currentNode = linkList.First;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != currentNode?.Value)
                {
                    isEqual = false;
                    break;
                }
                currentNode = currentNode.Next;
            }
            isEqual = isEqual && list.Count == linkList.Count;
            Console.Write("Списки одинаковы: ");
            Console.WriteLine(Convert.ToString(isEqual));
        }
    }
}