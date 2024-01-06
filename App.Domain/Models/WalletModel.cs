namespace App.Domain.Models
{
    public class WalletModel : BaseModel
    {
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private bool _default;
        public bool Default
        {
            get { return _default; }
            set { _default = value; }
        }
        
        
        
    }
}