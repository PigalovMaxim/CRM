const gulp = require('gulp');
const postcss = require('gulp-postcss');
const tailwindcss = require('tailwindcss');
const uglify = require('gulp-uglify');
const cleanCSS = require('gulp-clean-css');
const rename = require('gulp-rename');
const concat = require('gulp-concat');

gulp.task('minify-main-js', function () {
    return gulp.src('./wwwroot/js/main/*.js')
        .pipe(uglify())
        .pipe(concat('app.js'))
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest('./wwwroot/dist'));
});

gulp.task('minify-other-js', function () {
    return gulp.src('./wwwroot/js/other/*.js')
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./wwwroot/dist'));
});

gulp.task('minify-css', function () {
    return gulp.src('./wwwroot/css/*.css')
        .pipe(postcss([
            tailwindcss('./tailwind.config.js'),
        ]))
        .pipe(cleanCSS({compatibility: 'ie8'}))
        .pipe(concat('app.css'))
        .pipe(rename({suffix: '.min'}))
        .pipe(gulp.dest('./wwwroot/dist'));
});

gulp.task('watch', function () {
    gulp.watch('./wwwroot/js/**/*.js', gulp.series(['minify-main-js', 'minify-other-js']));
    gulp.watch('./Views/**/*.cshtml', gulp.series('minify-css'));
    gulp.watch('./wwwroot/css/*.css', gulp.series('minify-css'));
});

gulp.task('default', gulp.parallel('minify-main-js', 'minify-css', 'minify-other-js'));