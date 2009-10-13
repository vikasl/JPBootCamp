using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie> , IComparable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public  enum enuSortOrder { MovieTitleDesc,MovieTitleAsc,MovieTitleAndYear,MovieYearAsc,MovieYearDesc }

        private static enuSortOrder _sortOrder;

        public int rating { get; set; }

        public DateTime date_published { get; set; }

        public static enuSortOrder SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        public bool Equals(Movie other)
        {
            return other == null ? false : other.title == this.title;
        }

       public int CompareTo(Movie other)
        {
                switch (SortOrder)
                {
                    case enuSortOrder.MovieYearAsc:
                        return this.date_published.CompareTo(other.date_published);
                    case enuSortOrder.MovieYearDesc:
                        return other.date_published.CompareTo(this.date_published);
                    case enuSortOrder.MovieTitleDesc:
                        return other.title.CompareTo(this.title);
                    case enuSortOrder.MovieTitleAsc :
                        return this.title.CompareTo(other.title);
                    case enuSortOrder.MovieTitleAndYear :
                        return 0;
                    default:
                        return this.title.CompareTo(other.title);
                        break;
                }

        }
    }
}