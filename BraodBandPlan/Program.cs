namespace BraodBandPlan
{
    public interface IBroadbandPlan
    {
        public int GetBroadbandPlanAmount();
    }
    public class Black:IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 3000;
        public Black(bool isSubscriptionValid, int discountPercentage)
        {
            _isSubscriptionValid = isSubscriptionValid;
            _discountPercentage = discountPercentage;
            if(discountPercentage<0 || discountPercentage > 50)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public int GetBroadbandPlanAmount()
        {
            int disc = 0;
            if (_isSubscriptionValid)
            {
                disc += PlanAmount-PlanAmount * _discountPercentage / 100;
                return disc;
            }
            return PlanAmount;
        }
    }
    public class Gold : IBroadbandPlan
    {
        private readonly bool _isSubscriptionValid;
        private readonly int _discountPercentage;
        private const int PlanAmount = 1500;
        public Gold(bool isSubscriptionValid, int discountPercentage)
        {
            _isSubscriptionValid=isSubscriptionValid;
            _discountPercentage = discountPercentage;
            if(_discountPercentage<0 || _discountPercentage > 30)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public int GetBroadbandPlanAmount()
        {
            int disc = 0;
            if(_isSubscriptionValid)
            {
                disc += PlanAmount-PlanAmount * _discountPercentage / 100;
                return disc;
            }
            return PlanAmount;
        }
    }
    public class SubscribePlan
    {
        private readonly IList<IBroadbandPlan> _broadbandPlans;
        public SubscribePlan(IList<IBroadbandPlan> braodBandPlans)
        {
            _broadbandPlans = braodBandPlans;
            if (braodBandPlans == null)
            {
                throw new ArgumentNullException();
            }
        }
        public IList<Tuple<string,int>> GetSubscriptionPlan()
        {
            List<Tuple<string,int>> details= new List<Tuple<string,int>>();
            if (_broadbandPlans == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var items in _broadbandPlans)
            {
                details.Add(Tuple.Create(items.GetType().Name, items.GetBroadbandPlanAmount()));
            }
            return details;
        }
    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            var plans = new List<IBroadbandPlan>
            {
                new Black(true,50),
                new Black(false,10),
                new Gold(true,30),
                new Black(true,20),
                new Gold(false,20),
            };
            var subscriptionPlans = new SubscribePlan(plans);
            var result=subscriptionPlans.GetSubscriptionPlan();
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Item1} ,{item.Item2} ");
            }

        }
    }
}
