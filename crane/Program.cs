using System;
using System.Collections.Generic;

namespace crane
{
    class Apple
    {
        static void Main(string[] arg)
        {
            WorkItem workItem = new WorkItem("FixBug",
                "Fix all bugs in my code branch",
                new TimeSpan(3, 4, 0, 0));


            ChangeRequest changeRequest = new ChangeRequest("FixBug",
                "Fix all bugs in my code branch",
                new TimeSpan(3, 4, 0, 0),
                1);

            Console.WriteLine(workItem);
            
            Console.WriteLine(changeRequest);

            workItem.Update("work update", new TimeSpan(4, 3, 0, 0));

            Console.WriteLine(workItem);

            var rectangles = new List<Shape>
            {
                new Circle(),
                new Rectangle(),
                new Triangle()
            };

            foreach (var share in rectangles)
            {
                share.Draw();
            }

        }
    }

    public class Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle draw");
            base.Draw();
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle draw");
            base.Draw();
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Triancle draw");
            base.Draw();
        }
    }

    public class WorkItem
    {
        private static int currentID;

        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan jobLength { get; set; }

        public WorkItem()
        {
            ID = 0;
            Title = "Default title";
            Description = "Default description";
            jobLength = new TimeSpan();
        }

        public WorkItem(string title, string description, TimeSpan jobLen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = description;
            this.jobLength = jobLen;
        }

        static WorkItem() => currentID = 0;

        protected int GetNextID() => ++currentID;

        public void Update(string title, TimeSpan jobLen)
        {
            this.Title = title;
            this.jobLength = jobLen;
        }

        public override string ToString()
        {
            return $"{this.ID} - {this.Title}";
        }
    }

    public class ChangeRequest : WorkItem
    {
        protected int originalItemID { get; set; }

        public ChangeRequest() { }

        public ChangeRequest(string title, string description, TimeSpan jobLen, int originalID)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = description;
            this.jobLength = jobLen;
            this.originalItemID = originalID;
        }
    }
}
