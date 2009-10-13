using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        private IList<Movie> _movieCollection;
        public MovieLibrary(IList<Movie> list_of_movies)
        {
            _movieCollection = list_of_movies;
        }

        public IEnumerable <Movie> AllMoviesMatching(Predicate<Movie> moviematch)
        {
            foreach (Movie movie in _movieCollection)
            {
                if( moviematch(movie))
                   yield return movie;
                
            }
        }

        public IEnumerable<Movie> all_movies()
        {
            return _movieCollection ;
        }

        public void add(Movie movie)
        {
            if( !_movieCollection.Contains(movie))
                _movieCollection.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            List<Movie> movieList = new List<Movie>(_movieCollection);
            //movieList.Sort(new DescMovieTitleComparer());
            Movie.SortOrder = Movie.enuSortOrder.MovieTitleDesc;
            movieList.Sort();
            return movieList;
        }


        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            List<Movie> movieList = new List<Movie>(_movieCollection);
            //movieList.Sort( new AscMovieTitleComparer());
            Movie.SortOrder = Movie.enuSortOrder.MovieTitleAsc;
            movieList.Sort();
            return movieList;

        }
        
        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (Movie movie in _movieCollection)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                    yield return movie;
                
            }
            
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (Movie movie in _movieCollection)
            {
                if( movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney )
                    yield return movie;
            }
        }


        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            List<Movie> movieList = new List<Movie>(_movieCollection);
            movieList.Sort(new MovieStudioAndYearComparer());
            return movieList;

        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (Movie movie in _movieCollection)
            {
                if (movie.production_studio != ProductionStudio.Pixar )
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (Movie movie in _movieCollection)
            {
                if (movie.date_published.Year  > year )
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (Movie movie in _movieCollection)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (Movie movie in _movieCollection)
            {
                if (movie.genre == Genre.kids )
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (Movie movie in _movieCollection)
            {
                if (movie.genre == Genre.action )
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            List<Movie> movieList = new List<Movie>(_movieCollection);
            //movieList.Sort(new DescYearComparer());
            Movie.SortOrder = Movie.enuSortOrder.MovieYearDesc;
            movieList.Sort();
            return movieList;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            List<Movie> movieList = new List<Movie>(_movieCollection);
            //movieList.Sort(new AscYearComparer());
            Movie.SortOrder = Movie.enuSortOrder.MovieYearAsc ;
            movieList.Sort();
            return movieList;
        }
    }

    public class DescMovieTitleComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return y.title.CompareTo(x.title);
        }
    }

    public class DescYearComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            if (x.date_published < y.date_published)
                return 1;
            else if (x.date_published > y.date_published)
                return -1;
            else
                return 0;
        }
    }

    public class AscYearComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.date_published.CompareTo(y.date_published);
        }
    }

    public class MovieStudioAndYearComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            throw new NotImplementedException();
        }
    }

    public class AscMovieTitleComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.title.CompareTo(y.title);
        }
    }
}