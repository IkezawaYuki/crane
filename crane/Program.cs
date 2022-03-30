using System;

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
