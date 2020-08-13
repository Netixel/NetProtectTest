using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProtectTest
{
    class CollectionTesting
    {
        public static void Main()
        {

        }

    }
    public enum Position
    {
        TOP,
        MIDDLE,
        BOTTOM
    }

    class NewClassCollector
    {
        LinkedList<NewClass> objects;
        Dictionary<string, NewClass> ByName;
        SortedDictionary<int, HashSet<NewClass>> ByScore;
        Dictionary<Position, HashSet<NewClass>> ByPosition;

        public void Add(NewClass obj)
        {
            int score = obj.Score;
            if(ByScore.ContainsKey(score))
            {
                ByScore[score].Add(obj);
            }
            else
            {
                ByScore.Add(score, new HashSet<NewClass>() { obj });
            }


            Position pos = obj.Pos;
            if(ByPosition.ContainsKey(pos))
            {
                ByPosition[pos].Add(obj);
            }
            else
            {
                ByPosition.Add(pos, new HashSet<NewClass>() { obj });
            }


            ByName.Add(obj.Name, obj);
            
            
            obj.Node = objects.AddFirst(obj);
        }





        public void Remove(NewClass obj)
        {
            ByName.Remove(obj.Name);
            ByScore[obj.Score].Remove(obj);
            ByPosition[obj.Pos].Remove(obj);
            objects.Remove(obj);
        }

        public void RemoveByName(string name)
        {
            if (!ByName.ContainsKey(name))
                return;

            NewClass obj = ByName[name];
            Remove(obj);

        }
        public NewClass FindByName(string name)
        {
            if (ByName.ContainsKey(name))
                return ByName[name];

            return null;
        }
        public HashSet<NewClass> GetTopScore()
        {
            return ByScore.Last().Value;
        }

        public HashSet<NewClass> GetByPosition(Position pos)
        {
            if (ByPosition.ContainsKey(pos))
            {
                return ByPosition[pos];
            }
            return new HashSet<NewClass>();
        }


        public NewClassCollector()
        {
            ByPosition = new Dictionary<Position, HashSet<NewClass>>();
            ByScore = new SortedDictionary<int, HashSet<NewClass>>();
            objects = new LinkedList<NewClass>();
            ByName = new Dictionary<string, NewClass>();
        }
    }

    class NewClass
    {
        public string Name { get; set; }
        public int Score { get; set; }
        
        public Position Pos { get; set; }

        public object Payload { get; set; }


        public NewClass(string Name, int Starting_score, Position current_pos, object data)
        {
            this.Name = Name;
            this.Score = Starting_score;
            this.Pos = current_pos;
            this.Payload = data;
        }

        public LinkedListNode<NewClass> Node { get; set; }
    }


}
