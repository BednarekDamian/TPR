using System;

namespace Model
{
    public class SalesReasonModel
    {
        private int id;
        private string name;
        private string reasonSale;
        private DateTime modifTime;

        public SalesReasonModel() { }

        public SalesReasonModel(int id, string name, string reasonSale, DateTime modifTime)
        {
            this.id = id;
            this.name = name;
            this.reasonSale = reasonSale;
            this.modifTime = modifTime;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public string ReasonSale
        {
            get { return reasonSale; }
            set
            {
                reasonSale = value;
            }
        }
        public DateTime ModifTime
        {
            get { return modifTime; }
            set
            {
                modifTime = value;
            }
        }

    }
}
