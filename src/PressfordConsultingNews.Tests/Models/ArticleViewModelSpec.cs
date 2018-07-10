namespace PressfordConsultingNews.Tests.Models
{
    using System;
    using Machine.Specifications;
    using PressfordConsulting.News.Models;

    /// <summary>
    /// Tests for the <see cref="ArticleViewModel"/>
    /// </summary>
    public class ArticleViewModelSpec
    {
        [Subject("ArticleViewModel.FirstParagraphText")]
        public class When_selecting_first_paragraph
        {
            static string _paragraph1Text;
            static ArticleViewModel _sut;
            static string _result;

            Establish context = () =>
            {
                _paragraph1Text = "Paragraph 1";
                var paragraph1 = string.Format("<p>{0}</p>", _paragraph1Text);
                var content = string.Format("{0}<p>Paragraph 2</p><p>paragraph 3</p", paragraph1);
                _sut = new ArticleViewModel("Article title", content, "a@b.com", DateTime.Now, 0);
            };

            Because of = () => _result = _sut.FirstParagraphText;

            It Should_select_the_text_of_the_first_paragraph_from_the_content =
                () => _result.ShouldEqual(_paragraph1Text);
        }
    }
}
