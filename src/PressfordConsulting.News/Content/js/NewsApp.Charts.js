NewsApp.Charts = (function ($, Chart, undefined) {
    var settings = {};

    var init = function(chartSelector) {
        settings.chartSelector = chartSelector;

        settings.context = document.getElementById(settings.chartSelector).getContext("2d");
        Chart.defaults.global.responsive = true;
        Chart.defaults.global.tooltipFillColor = "#bdbdbd";
        Chart.defaults.global.tooltipFontColor = "#333";
        Chart.defaults.global.tooltipTemplate = "<%if (label){%><%=label%>: <%}%><%= value %> likes";
    };

    var customChart = function(selector, data) {
        init(selector);

        var options = {};
        var newChart = new Chart(settings.context).ArticleChart(data, options);

        $('#' + settings.chartSelector).click(
            function(evt) {
                var activePoints = newChart.getSegmentsAtEvent(evt);
                var url = "/Article/Read/" + activePoints[0].articleId;
                window.location.href = url;
            });
    };

    // Need to create a custom chart so that the article identifier can be included
    // This will be used to enable the user to click on the segment and go to read 
    // the article.
    Chart.types.Doughnut.extend({
        name: "ArticleChart",
        addData: function (segment, atIndex, silent) {
            var index = atIndex || this.segments.length;
            this.segments.splice(index, 0, new this.SegmentArc({
                value: segment.value,
                outerRadius: (this.options.animateScale) ? 0 : this.outerRadius,
                innerRadius: (this.options.animateScale) ? 0 : (this.outerRadius / 100) * this.options.percentageInnerCutout,
                fillColor: segment.color,
                highlightColor: segment.highlight || segment.color,
                showStroke: this.options.segmentShowStroke,
                strokeWidth: this.options.segmentStrokeWidth,
                strokeColor: this.options.segmentStrokeColor,
                startAngle: Math.PI * this.options.startAngle,
                circumference: (this.options.animateRotate) ? 0 : this.calculateCircumference(segment.value),
                label: segment.label,
                //add option passed
                articleId: segment.articleId
            }));
            if (!silent) {
                this.reflow();
                this.update();
            }
        },
    });

    return {
        init: init,
        chart: customChart
    };
})(jQuery, Chart);