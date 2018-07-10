namespace PressfordConsultingNews.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using Machine.Specifications;
    using Moq;
    using PressfordConsulting.News.Data.Resources;
    using PressfordConsulting.News.Data.Services;
    using PressfordConsulting.News.Models;
    using PressfordConsulting.News.Services;
    using It = Machine.Specifications.It;
    using MockIt = Moq.It;

    public class ArticleServiceSpec
    {
        [Subject("Article Service: ConvertToArticle")]
        public class When_converting_from_articleviewmodel_to_article
        {
            static ArticleViewModel _model;
            static DateTime _pubDate;
            static Article _result;

            Establish context = () =>
            {
                _pubDate = DateTime.Now;
                _model = new ArticleViewModel(
                    Helper.ArticleTitle,
                    Helper.ArticleContent,
                    Helper.ArticleImage,
                    _pubDate)
                {
                    Image = new Uri(Helper.ArticleImage),
                    Id = 1
                };
            };

            Because of = () => _result = ArticleService.ConvertToArticle(_model, Helper.Username);

            It Should_have_the_correct_article_identifier = () => _result.ArticleId.ShouldEqual(1);

            It Should_have_the_correct_title = () => _result.Title.ShouldEqual(Helper.ArticleTitle);

            It Should_have_the_correct_content = () => _result.Content.ShouldEqual(Helper.ArticleContent);

            It Should_have_the_correct_author = () => _result.Author.ShouldEqual(Helper.Username);

            It Should_have_the_correct_image = () => _result.Image.ShouldEqual(Helper.ArticleImage);

            It Should_have_the_correct_published_date = () =>
                _result.PublishDate.ToLongDateString().ShouldEqual(_pubDate.ToLongDateString());
        }

        [Subject("Article Service: ConvertToArticle")]
        public class When_converting_from_articleviewmodel_to_article_with_no_image
        {
            static ArticleViewModel _model;
            static DateTime _pubDate;
            static Article _result;

            Establish context = () =>
            {
                _pubDate = DateTime.Now;

                _model = new ArticleViewModel(
                    Helper.ArticleTitle,
                    Helper.ArticleContent,
                    Helper.Username,
                    _pubDate)
                {
                    Id = 1
                };
            };

            Because of = () => _result = ArticleService.ConvertToArticle(_model, Helper.Username);

            It Should_have_the_correct_article_identifier = () => _result.ArticleId.ShouldEqual(1);

            It Should_have_the_correct_title = () => _result.Title.ShouldEqual(Helper.ArticleTitle);

            It Should_have_the_correct_content = () => _result.Content.ShouldEqual(Helper.ArticleContent);

            It Should_have_the_correct_author = () => _result.Author.ShouldEqual(Helper.Username);

            It Should_have_the_correct_image = () => _result.Image.ShouldBeNull();

            It Should_have_the_correct_published_date = () =>
                _result.PublishDate.ToLongDateString().ShouldEqual(_pubDate.ToLongDateString());
        }

        [Subject("Article Service: ConvertToArticleViewModel")]
        public class When_converting_from_article_to_articleviewmodel
        {
            static Article _model;
            static DateTime _pubDate;
            static List<ArticleLike> _likes;
            static ArticleViewModel _result;

            Establish context = () =>
            {
                _pubDate = DateTime.Now;
                _likes = new List<ArticleLike>
                {
                    new ArticleLike(1, Helper.Username)
                };

                _model = new Article(Helper.ArticleTitle,
                    Helper.ArticleContent,
                    Helper.Username,
                    _pubDate)
                {
                    Image = Helper.ArticleImage,
                    ArticleId = 1,
                    Likes = _likes,
                };
            };

            Because of = () => _result = ArticleService.ConvertToArticleViewModel(_model, Helper.Username);

            It Should_have_the_correct_article_identifier = () => _result.Id.ShouldEqual(1);

            It Should_have_the_correct_title = () => _result.Title.ShouldEqual(Helper.ArticleTitle);

            It Should_have_the_correct_content = () => _result.Content.ShouldEqual(Helper.ArticleContent);

            It Should_have_the_correct_author = () => _result.Author.ShouldEqual(Helper.Username);

            It Should_have_the_correct_image = () => _result.Image.ShouldEqual(new Uri(Helper.ArticleImage));

            It Should_have_the_correct_number_of_likes = () => _result.LikeCount.ShouldEqual(1);

            It Should_have_the_correct_published_date = () =>
                _result.PublishDate.ToLongDateString().ShouldEqual(_pubDate.ToLongDateString());
        }

        [Subject("Article Service: ConvertToArticleViewModel")]
        public class When_converting_from_article_to_articleviewmodel_with_no_image
        {
            static Article _model;
            static DateTime _pubDate;
            static List<ArticleLike> _likes;
            static ArticleViewModel _result;

            Establish context = () =>
            {
                _pubDate = DateTime.Now;
                _likes = new List<ArticleLike>
                {
                    new ArticleLike(1, Helper.Username)
                };

                _model = new Article(
                    Helper.ArticleTitle,
                    Helper.ArticleContent,
                    Helper.Username,
                    _pubDate)
                {
                    ArticleId = 1,
                    Likes = _likes,
                };
            };

            Because of = () => _result = ArticleService.ConvertToArticleViewModel(_model, Helper.Username);

            It Should_have_the_correct_article_identifier = () => _result.Id.ShouldEqual(1);

            It Should_have_the_correct_title = () => _result.Title.ShouldEqual(Helper.ArticleTitle);

            It Should_have_the_correct_content = () => _result.Content.ShouldEqual(Helper.ArticleContent);

            It Should_have_the_correct_author = () => _result.Author.ShouldEqual(Helper.Username);

            It Should_have_the_correct_number_of_likes = () => _result.LikeCount.ShouldEqual(1);

            It Should_have_the_correct_image = () => _result.Image.ShouldBeNull();

            It Should_have_the_correct_published_date = () =>
                _result.PublishDate.ToLongDateString().ShouldEqual(_pubDate.ToLongDateString());
        }

        /// <summary>
        /// Creates the context for all the tests for <see cref="ArticleService.GetArticles"/>
        /// </summary>
        public abstract class GetArticlesContext
        {
            protected static ArticleService Sut;
            protected static Mock<IArticleDataService> MockedDataService;
            protected static int NumberOfArticles = 5;

            Establish context = () =>
            {
                MockedDataService = new Mock<IArticleDataService>();
                Sut = new ArticleService(MockedDataService.Object);
            };
        }

        [Subject("Article Service: GetArticles")]
        public class When_getting_latest_articles : GetArticlesContext
        {
            Establish context = () =>
                MockedDataService
                    .Setup(x => x.GetLatestArticles(MockIt.IsAny<int>()))
                    .Returns(new List<Article>());

            Because of =
                () =>
                    Sut.GetArticles(
                        ArticleService.ArticleType.Latest,
                        NumberOfArticles,
                        Helper.Username);

            It should_call_the_GetLatestArticles_method_in_the_data_service_once =
                () =>
                    MockedDataService
                        .Verify(x => x.GetLatestArticles(NumberOfArticles), Times.Once);
        }

        [Subject("Article Service: GetArticles")]
        public class When_getting_most_popular_articles : GetArticlesContext
        {
            Establish context = () =>
                MockedDataService
                    .Setup(x => x.GetMostPopularArticles(MockIt.IsAny<int>()))
                    .Returns(new List<Article>());

            Because of =
                () =>
                    Sut.GetArticles(
                        ArticleService.ArticleType.MostPopular,
                        NumberOfArticles,
                        Helper.Username);

            It should_call_the_GetMostPopularArticles_method_in_the_data_service_once =
                () =>
                    MockedDataService
                        .Verify(x => x.GetMostPopularArticles(NumberOfArticles), Times.Once);
        }

        [Subject("Article Service: GetArticles")]
        public class When_getting_all_articles : GetArticlesContext
        {
            Establish context = () =>
                MockedDataService
                    .Setup(x => x.GetAllArticles())
                    .Returns(new List<Article>());

            Because of =
                () =>
                    Sut.GetArticles(
                        ArticleService.ArticleType.All,
                        NumberOfArticles,
                        Helper.Username);

            It should_call_the_GetAllArticles_method_in_the_data_service_once =
                () =>
                    MockedDataService.Verify(x => x.GetAllArticles(), Times.Once);
        }

        [Subject("Article Service: GetPieChartData")]
        public class When_getting_pie_chart_data
        {
            private static string _expected;
            private const int ExpectedLikeCount = 50;
            private const int ExpectedArticleId = 1;
            private static ArticleViewModel _article;
            private static List<ArticleViewModel> _articleList;
            private static string _result;

            Establish context = () =>
            {
                _article = new ArticleViewModel(
                    Helper.ArticleTitle,
                    Helper.ArticleContent,
                    Helper.Username,
                    DateTime.Now,
                    ExpectedLikeCount)
                {
                    Id = ExpectedArticleId
                };

                _articleList = new List<ArticleViewModel>
                {
                    _article
                };

                _expected = string.Format(
                    "{{" +
                    "value: {0}," +
                    "color: '{1}'," +
                    "highlight: '#1de9b6'," +
                    "label: '{2}'," +
                    "articleId: '{3}'" +
                    "}}",
                    ExpectedLikeCount,
                    "#004d40",
                    Helper.ArticleTitle,
                    ExpectedArticleId);
            };

            Because of = () => _result = ArticleService.GetPieChartData(_articleList);

            It Should_return_the_correctly_formatted_string =
                () => _result.ShouldEqual(_expected);
        }

        [Subject("Article Service: GetPieChartData")]
        public class When_getting_pie_chart_data_with_no_articles
        {
            private static string _expected;
            private static List<ArticleViewModel> _articleList;
            private static string _result;

            Establish context = () =>
            {
                _articleList = new List<ArticleViewModel>();

                _expected = string.Empty;
            };

            Because of = () => _result = ArticleService.GetPieChartData(_articleList);

            It Should_return_an_empty_string =
                () => _result.ShouldEqual(_expected);
        }
    }
}
