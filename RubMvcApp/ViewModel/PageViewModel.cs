namespace RubApp.ViewModel {

    public class PageViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage() {
            if (this.PageNumber > 1) {
                return true;
            }
            else {
                return false;
            }
        }
        public bool HasNextPage() {
            if (this.PageNumber < this.TotalPages) {
                return true;
            }
            else {
                return false;
            }
        }
        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.TotalPages = (int)System.Math.Ceiling(count / (double)pageSize);
        }
    }
}