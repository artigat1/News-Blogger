/// <vs BeforeBuild='install' SolutionOpened='watch' />
/// 
// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var minifyCSS = require('gulp-minify-css');
var copy = require('gulp-copy');
var bower = require('gulp-bower');
var sourcemaps = require('gulp-sourcemaps');
var watch = require('gulp-watch');

var config = {
    //JavaScript files that will be combined into a jquery bundle
    jquerysrc: [
        'bower_components/jquery/dist/jquery.min.js',
        'bower_components/jquery-validation/dist/jquery.validate.min.js',
        'bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js'
    ],
    jquerybundle: 'Scripts/jquery-bundle.min.js',

    // Materlialize
    materializecss: 'bower_components/materialize/dist/css/materialize.min.css',
    materializethemecss: 'bower_components/materialize/templates/masonry-template/css/style.css',
    materializesrc: [
        'bower_components/materialize/dist/js/materialize.min.js',
        'bower_components/materialize/templates/masonry-template/js/masonry.pkgd.min.js',
        'bower_components/imagesloaded/imagesloaded.pkgd.min.js',
        'Content/js/Masonry-Template.init.js'
    ],
    materializebundle: 'Content/dist/js/materialize-bundle.min.js',

    // Froala Editor
    froalasrc: [
        'bower_components/froala/js/froala_editor.min.js',
        'bower_components/froala/js/plugins/colors.min.js',
        'bower_components/froala/js/plugins/font_family.min.js',
        'bower_components/froala/js/plugins/font_size.min.js',
        'bower_components/froala/js/plugins/fullscreen.min.js',
        'bower_components/froala/js/plugins/lists.min.js',
        'bower_components/froala/js/plugins/tables.min.js',
        'bower_components/froala/js/plugins/video.min.js'
    ],
    froalabundle: 'Content/dist/js/froala-editor-bundle.min.js',
    froalacss: 'bower_components/froala/css/froala_editor.min.css',
    froalatheme: 'bower_components/froala/css/themes/gray.min.css',

    // Chart.js
    chartjssrc: [
        'bower_components/chartjs/Chart.min.js'
    ],
    chartjsbundle: 'Content/dist/js/chartjs-bundle.min.js',

    // This is used by Froala editor for the icons on the edit ribbon.
    fontawesomecss: 'bower_components/font-awesome/css/font-awesome.min.css',

    // Fonts
    materialdesignfont: 'bower_components/materialize/dist/font/material-design-icons/*.*',
    robotofont: 'bower_components/materialize/dist/font/roboto/*.*',

    // Site js bundled
    sitesrc: [
        'Content/js/NewsApp.Core.js',
        'Content/js/NewsApp.Charts.js',
        'Content/js/NewsApp.Editor.js',
        'Content/js/NewsApp.Like.js'
    ],
    sitebundle: 'Content/dist/js/site-bundle.min.js',

    // Main site styles
    appcss: 'Content/css/Site.css',

    // App output
    cssout: 'Content/dist/css',
    jsout: 'Content/dist/js',
    materialdesignfontout: 'Content/dist/font/material-design-icons',
    robotofontout: 'Content/dist/font/roboto'
}

// Synchronously delete the output script file(s)
gulp.task('clean-vendor-scripts', function (cb) {
    del([
        config.jquerybundle,
        config.jquerybundle,
        config.froalabundle,
        config.chartjsbundle,
        config.sitebundle
    ], cb);
});

//Create a jquery bundled file
gulp.task('jquery-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.jquerysrc)
        .pipe(concat('jquery-bundle.min.js'))
        .pipe(gulp.dest(config.jsout));
});

//Create a froala editor bundled file
gulp.task('froala-editor-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.froalasrc)
        .pipe(concat('froala-editor-bundle.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(config.jsout));
});

//Create a materialize bundled file
gulp.task('materialize-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.materializesrc)
        .pipe(concat('materialize-bundle.min.js'))
        .pipe(gulp.dest(config.jsout));
});

//Create a Chart.js bundled file
gulp.task('chartjs-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.chartjssrc)
        .pipe(concat('chartjs-bundle.min.js'))
        .pipe(gulp.dest(config.jsout));
});

//Create site js bundled file
gulp.task('site-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.sitesrc)
        .pipe(concat('site-bundle.js'))
        .pipe(gulp.dest(config.jsout))
        .pipe(uglify())
        .pipe(concat('site-bundle.min.js'))
        .pipe(gulp.dest(config.jsout));
});

// Include all the required font files
gulp.task('fonts', ['fonts-material', 'fonts-roboto'], function () {

});

gulp.task('fonts-material', ['clean-styles', 'bower-restore'], function () {
    return gulp.src(config.materialdesignfont)
        .pipe(gulp.dest(config.materialdesignfontout));
});

gulp.task('fonts-roboto', ['clean-styles', 'bower-restore'], function () {
    return gulp.src(config.robotofont)
        .pipe(gulp.dest(config.robotofontout));
});

// Synchronously delete the output style files (css / fonts)
gulp.task('clean-styles', function (cb) {
    del([config.cssout], cb);
});

gulp.task('css', ['clean-styles', 'bower-restore'], function () {
    return gulp.src([
            config.materializecss,
            config.materializethemecss,
            config.fontawesomecss,
            config.froalacss,
            config.froalatheme,
            config.appcss
        ])
        .pipe(concat('app.css'))
        .pipe(gulp.dest(config.cssout))
        .pipe(minifyCSS())
        .pipe(concat('app.min.css'))
        .pipe(gulp.dest(config.cssout));
});

// Combine all the vendor files from bower into bundles (output to the Scripts folder)
gulp.task('vendor-scripts', [
    'jquery-bundle',
    'froala-editor-bundle',
    'materialize-bundle',
    'chartjs-bundle',
    'site-bundle'
], function () {

});

// Combine and minify css files and output fonts
gulp.task('styles', ['css', 'fonts'], function () {

});

// Watch for changes
gulp.task('watch', function () {
    watch('Content/js/**/*.js/', ['site-bundle']);
    watch('Content/css/**/*.css/', ['css']);
});

//Restore all bower packages
gulp.task('bower-restore', function () {
    return bower();
});

//Set a default tasks 
gulp.task('install', ['vendor-scripts', 'styles'], function () {

});